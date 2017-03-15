Imports DailyPlayers_v2.clsPublicFunctions
Imports System.Data.Odbc
Imports DailyPlayers_v2.clsPlayerStats
Imports DailyPlayers_v2.clsMeta

Public Class frmDPv2
    Public LastDriveID(5) As Int64
    Public LastPlayID(5) As Int64
    Public LastYard(5) As Int64
    Public BallY(5) As Integer
    Public pubPlayerStats(5) As clsPlayerStats
    Public pubMeta As clsMeta

    Public Function sqlQueryFunction(ByVal sqlSelect As String)
        'Dim strPlayer(6) As myPlayer

        Dim StrConn As String = "Dsn=PostgreSQLnfl;database=nfldb;server=127.0.0.1;port=5432;uid=nfldb;pwd=nfldb;"
        Dim MyConn As New OdbcConnection(StrConn)
        'Dim MySelect As String = "SELECT game.season_year as Year, game.week, player.full_name, player.position, player.team, game.home_team, game.away_team, sum(play_player.passing_int), sum(play_player.passing_tds), sum(play_player.passing_twoptm), sum(play_player.passing_yds), sum(play_player.receiving_yds), sum(play_player.receiving_tds), sum(play_player.receiving_twoptm), sum(play_player.rushing_yds), sum(play_player.rushing_tds), sum(play_player.rushing_twoptm), sum(play_player.fumbles_tot), sum(play_player.fumbles_lost), sum(play_player.kickret_yds), sum(play_player.kickret_tds), sum(play_player.puntret_yds), sum(play_player.puntret_tds) FROM play_player LEFT JOIN player ON player.player_id = play_player.player_id LEFT JOIN game ON game.gsis_id = play_player.gsis_id WHERE game.season_year >= 2015 AND game.week = 5 and game.season_type = 'Regular' and player.position in ('QB','WR','RB','TE') and player.player_id in ('" + sqlSelect + "') group by game.season_year, game.week, game.gamekey, player.position, player.full_name, player.team, game.home_team, game.away_team order by game.season_year, game.week, game.gamekey"
        Dim mySelect As String = sqlSelect
        Dim MyDataAdapter As New OdbcDataAdapter
        MyConn.Open()
        Dim MyTable As New DataTable

        MyDataAdapter.SelectCommand = New OdbcCommand(mySelect, MyConn)
        MyDataAdapter.Fill(MyTable)
        'Me.BindingSource1.DataSource = MyTable
        'Label7.Text = MyTable.Rows(0).Item(16).ToString

        MyConn.Close()

        Return MyTable
    End Function

    Private Sub frmDPv2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'pubPlayerStats(1) = New clsPlayerStats
        pubMeta = New clsMeta
        Dim sqlStatement As String
        Dim thisTable As DataTable

        For iCount = 0 To 4
            pubPlayerStats(iCount) = New clsPlayerStats
            LastDriveID(iCount) = 0
            LastPlayID(iCount) = 0
        Next
        For iCount = 0 To 4
            LastYard(iCount) = 205
        Next

        BallY(0) = 51
        BallY(1) = 98
        BallY(2) = 144
        BallY(3) = 189
        BallY(4) = 235

        sqlStatement = "select season_type, season_year, week " & _
                    "from meta "

        thisTable = sqlQueryFunction(sqlStatement)

        If thisTable.Rows.Count() > 0 Then
            pubMeta.Week = thisTable.Rows(0).Item(2).ToString
            pubMeta.Season = thisTable.Rows(0).Item(0).ToString
            pubMeta.Year = thisTable.Rows(0).Item(1).ToString
        End If


        'LastDriveID = CInt(TextBox1.Text)
        'LastPlayID = CInt(TextBox2.Text)
        'LastYard = 205

        CreateLiveScoreBox()
        'updateLiveScores()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        getPlays()

        updateLiveScores()

        'readDB()

    End Sub

    Private Sub getPlays()
        Dim sqlStatement As String
        Dim thisTable As DataTable
        Dim intI As Int64
        Dim addYds As Int64
        Dim intYardLine As Int64
        Dim newYardLine As Int64
        Dim playerX, playerY As Int64
        Dim intPlayPoints As Double


        'pubPlayerStats.GameID = TextBox3.Text

        For iCount = 0 To 4
            If pubPlayerStats(iCount).GameID = "" Then
                TextBox3.Text = "Missing GameID"
                getPlayersGame(pubPlayerStats(iCount).PlayerID, iCount)
            End If

            intI = 0

            Debug.Write("GameID(" & iCount & "): " + pubPlayerStats(iCount).GameID + vbCrLf)
            Debug.Write("PlayerID(" & iCount & "): " + pubPlayerStats(iCount).PlayerID + vbCrLf)
            sqlStatement = "select pp.drive_id, pp.play_id, p.full_name, pl.""time"", pl.pos_team, pl.yardline, pl.description, pl.down, pl.yards_to_go, pl.time_inserted, pl.time_updated, pp.*, p.* " &
            "from play_player pp " &
            "left join player p on (pp.player_id = p.player_id) " &
            "left join play pl on (pp.gsis_id = pl.gsis_id and pp.play_id = pl.play_id) " &
            "left join game g on (pp.gsis_id = g.gsis_id) " &
            "where pp.gsis_id = '" + pubPlayerStats(iCount).GameID + "' " &
            "and (pp.drive_id >= " & LastDriveID(iCount) & ") " &
            "and (pp.play_id > " & LastPlayID(iCount) & ") " &
            "order by pp.drive_id, pp.play_id"

            '"and (pp.drive_id >= " & LastDriveID & " and pp.drive_id <= " + TextBox1.Text + ") " & _
            '"and (pp.play_id > " & LastPlayID & " and pp.play_id < " + TextBox2.Text + ") " & _

            thisTable = sqlQueryFunction(sqlStatement)
            'MsgBox(sqlStatement)

            If thisTable.Rows.Count > 0 Then
                For Each row In thisTable.Rows
                    intPlayPoints = 0

                    If thisTable.Rows(intI).Item(14) = pubPlayerStats(iCount).PlayerID Then
                        'my player has the ball
                        addYds = CInt(thisTable.Rows(intI).Item("passing_yds")) + CInt(thisTable.Rows(intI).Item("receiving_yds")) + CInt(thisTable.Rows(intI).Item("rushing_yds"))
                        If CInt(thisTable.Rows(intI).Item("passing_int")) > 0 Or CInt(thisTable.Rows(intI).Item("fumbles_lost")) > 0 Then
                            addYds = 1
                        End If

                        If addYds <> 0 Then
                            If thisTable.Rows(intI).Item("position").ToString = "QB" Then

                                If CInt(thisTable.Rows(intI).Item("passing_yds")) > 0 Or CInt(thisTable.Rows(intI).Item("rushing_yds")) > 0 Or CInt(thisTable.Rows(intI).Item("passing_int")) > 0 Or CInt(thisTable.Rows(intI).Item("fumbles_lost")) > 0 Then
                                    If CInt(thisTable.Rows(intI).Item("passing_yds")) > 0 Then
                                        pubPlayerStats(iCount).PassingYards = pubPlayerStats(iCount).PassingYards + addYds
                                        intPlayPoints = ((1 / 25) * addYds)
                                    End If
                                    If CInt(thisTable.Rows(intI).Item("rushing_yds")) > 0 Then
                                        pubPlayerStats(iCount).RushingYds = pubPlayerStats(iCount).RushingYds + addYds
                                        intPlayPoints = ((1 / 10) * addYds)
                                    End If

                                    If CInt(thisTable.Rows(intI).Item("passing_yds")) > 40 Then
                                        pubPlayerStats(iCount).Plus40YdCompletion = pubPlayerStats(iCount).Plus40YdCompletion + 1
                                        intPlayPoints = intPlayPoints + 1
                                    End If
                                    If CInt(thisTable.Rows(intI).Item("passing_yds")) > 40 And CInt(thisTable.Rows(intI).Item("passing_tds")) > 0 Then
                                        pubPlayerStats(iCount).Plus40YdTDs = pubPlayerStats(iCount).Plus40YdTDs + 1
                                        intPlayPoints = intPlayPoints + 2
                                    End If
                                    If CInt(thisTable.Rows(intI).Item("rushing_yds")) > 40 Then
                                        pubPlayerStats(iCount).Plus40YdRun = pubPlayerStats(iCount).Plus40YdRun + 1
                                        intPlayPoints = intPlayPoints + 1
                                    End If
                                    If CInt(thisTable.Rows(intI).Item("passing_tds")) = 1 Then
                                        pubPlayerStats(iCount).PassingTDs = pubPlayerStats(iCount).PassingTDs + 1
                                        intPlayPoints = intPlayPoints + 6
                                    End If
                                    If CInt(thisTable.Rows(intI).Item("rushing_tds")) = 1 Then
                                        pubPlayerStats(iCount).RushingTDs = pubPlayerStats(iCount).RushingTDs + 1
                                        intPlayPoints = intPlayPoints + 6
                                    End If
                                    If CInt(thisTable.Rows(intI).Item("passing_int")) = 1 Then
                                        pubPlayerStats(iCount).Interceptions = pubPlayerStats(iCount).Interceptions + 1
                                        intPlayPoints = intPlayPoints - 1
                                        addYds = 0
                                    End If
                                    If CInt(thisTable.Rows(intI).Item("fumbles_lost")) = 1 Then
                                        pubPlayerStats(iCount).FumblesLost = pubPlayerStats(iCount).FumblesLost + 1
                                        intPlayPoints = intPlayPoints - 2
                                        addYds = 0
                                    End If

                                End If

                                pubPlayerStats(iCount).PlayerPoints = pubPlayerStats(iCount).PlayerPoints + intPlayPoints
                                lblQBPoints.Text = FormatNumber(pubPlayerStats(iCount).PlayerPoints, 2)
                                playerY = 51
                            ElseIf thisTable.Rows(intI).Item("position").ToString = "RB" Then
                                If CInt(thisTable.Rows(intI).Item("passing_yds")) > 0 Or CInt(thisTable.Rows(intI).Item("rushing_yds")) > 0 Or CInt(thisTable.Rows(intI).Item("passing_int")) > 0 Or CInt(thisTable.Rows(intI).Item("fumbles_lost")) > 0 Then
                                    If CInt(thisTable.Rows(intI).Item("rushing_yds")) > 0 Then
                                        pubPlayerStats(iCount).RushingYds = pubPlayerStats(iCount).RushingYds + addYds
                                        intPlayPoints = ((1 / 10) * addYds)
                                    End If
                                    If CInt(thisTable.Rows(intI).Item("rushing_yds")) > 40 Then
                                        pubPlayerStats(iCount).Plus40YdRun = pubPlayerStats(iCount).Plus40YdRun + 1
                                        intPlayPoints = intPlayPoints + 1
                                    End If
                                    If CInt(thisTable.Rows(intI).Item("rushing_tds")) = 1 Then
                                        pubPlayerStats(iCount).RushingTDs = pubPlayerStats(iCount).RushingTDs + 1
                                        intPlayPoints = intPlayPoints + 6
                                    End If
                                    If CInt(thisTable.Rows(intI).Item("fumbles_lost")) = 1 Then
                                        pubPlayerStats(iCount).FumblesLost = pubPlayerStats(iCount).FumblesLost + 1
                                        intPlayPoints = intPlayPoints - 2
                                        addYds = 0
                                    End If

                                End If
                                pubPlayerStats(iCount).PlayerPoints = pubPlayerStats(iCount).PlayerPoints + intPlayPoints
                                lblRB1Points.Text = FormatNumber(pubPlayerStats(iCount).PlayerPoints, 2)
                                playerY = 98

                                'pubPlayerStats(iCount).PlayerPoints = pubPlayerStats(iCount).PlayerPoints + ((1 / 10) * addYds)
                            ElseIf thisTable.Rows(intI).Item("position").ToString = "WR" Then
                                pubPlayerStats(iCount).PlayerPoints = pubPlayerStats(iCount).PlayerPoints + ((1 / 10) * addYds)
                            End If
                        End If
                        intYardLine = CInt(thisTable.Rows(intI).Item(5).ToString.Replace("(", "").Replace(")", ""))
                        newYardLine = calcYardLine(intYardLine, addYds)
                        MoveBall(newYardLine, BallY(iCount), iCount)

                        'pbField_Paint(Me.pbField,e, oldYardLine:=, newYardLine)
                        dgPlayersPlay.Rows.Insert(0, thisTable.Rows(intI).Item(2).ToString, FormatNumber(intPlayPoints, 2), thisTable.Rows(intI).Item(7).ToString, thisTable.Rows(intI).Item(8).ToString, thisTable.Rows(intI).Item(6).ToString)
                        LastYard(iCount) = newYardLine
                        DrawLine(LastYard(iCount), newYardLine, True, iCount)
                        'lblK.Text = LastDriveID.ToString
                        'lblDef.Text = LastPlayID.ToString
                        'lblTE.Text = newYardLine
                    ElseIf thisTable.Rows(intI).Item(4) = pubPlayerStats(iCount).Team Then
                        If thisTable.Rows(intI).Item(15) = pubPlayerStats(iCount).Team Then
                            'my players team has the ball
                            'addYds = CInt(thisTable.Rows(intI).Item(82))
                            addYds = CInt(thisTable.Rows(intI).Item("passing_yds")) + CInt(thisTable.Rows(intI).Item("receiving_yds")) + CInt(thisTable.Rows(intI).Item("rushing_yds"))
                            intYardLine = CInt(thisTable.Rows(intI).Item(5).ToString.Replace("(", "").Replace(")", ""))
                            newYardLine = calcYardLine(intYardLine, addYds)
                            If iCount = 0 Then
                                playerY = 51
                            ElseIf iCount = 1 Then
                                playerY = 98
                            End If
                            MoveBall(newYardLine, BallY(iCount), iCount)
                            'DrawLine(LastYard, newYardLine, False)
                            LastYard(iCount) = newYardLine
                            DrawLine(LastYard(iCount), newYardLine, True, iCount)
                            'dgPlayersPlay.Rows.Insert(0, thisTable.Rows(intI).Item(2).ToString, pubPlayerStats.PlayerPoints.ToString, thisTable.Rows(intI).Item(7).ToString, thisTable.Rows(intI).Item(8).ToString, thisTable.Rows(intI).Item(6).ToString)
                        End If
                    Else
                        'opposing team has the ball
                        If iCount = 0 Then
                            playerY = 51
                        ElseIf iCount = 1 Then
                            playerY = 98
                        End If
                        MoveBall(205, BallY(iCount), iCount)
                        DrawLine(0, 0, False, iCount)
                    End If
                    intI = intI + 1
                Next
                LastDriveID(iCount) = thisTable.Rows(intI - 1).Item(0)
                LastPlayID(iCount) = thisTable.Rows(intI - 1).Item(1)

            Else
                'MsgBox("No plays")
            End If

        Next
    End Sub

    Private Function calcYardLine(ByVal yardLine As Int64, ByVal addYards As Int64)
        Dim returnYards As Int64

        If yardLine < 0 Then
            returnYards = ((((50 + addYards) + yardLine) * 8.57) + 205)
        ElseIf yardLine > 0 And yardLine < 1108 Then
            returnYards = (1062 - ((50 - (yardLine + addYards)) * 8.57))
        Else
            returnYards = 1108
        End If

        Return returnYards
    End Function

    Private Sub readDB()
        Dim sqlStatement As String
        Dim thisTable As DataTable
        Dim thisTable2 As DataTable
        Dim intYardLine As Int64
        Dim AddYds As Int64
        Dim intCalcYardLine As Decimal
        Dim bolTD As Boolean

        For iCount = 0 To 4

            sqlStatement = "select pp.drive_id, pp.play_id, p.full_name, pl.""time"", pl.pos_team, pl.yardline, pl.description, pl.down, pl.yards_to_go, pl.time_inserted, pl.time_updated, pp.* " &
                    "from play_player pp " &
                    "left join player p on (pp.player_id = p.player_id) " &
                    "left join play pl on (pp.gsis_id = pl.gsis_id and pp.play_id = pl.play_id) " &
                    "left join game g on (pp.gsis_id = g.gsis_id) " &
                    "where pp.gsis_id = '" + pubPlayerStats(iCount).GameID + "' and pp.player_id = '" + pubPlayerStats(iCount).PlayerID + "' " &
                    "and (pp.drive_id >= " & LastDriveID(iCount) & " and pp.drive_id <= " + TextBox1.Text + ") " &
                    "and (pp.play_id > " & LastPlayID(iCount) & " and pp.play_id < " + TextBox2.Text + ") " &
                    "order by pp.drive_id desc, pp.play_id desc"

            thisTable = sqlQueryFunction(sqlStatement)
            If thisTable.Rows.Count > 0 Then
                'pubPlayerStats.PlayerID = thisTable.Rows(0).Item(12).ToString
                AddYds = CInt(thisTable.Rows(0).Item(82))
                intYardLine = CInt(thisTable.Rows(0).Item(5).ToString.Replace("(", "").Replace(")", ""))
                pubPlayerStats(iCount).PassingYards = pubPlayerStats(iCount).PassingYards + AddYds
                If AddYds > 0 Then
                    pubPlayerStats(iCount).PlayerPoints = pubPlayerStats(iCount).PlayerPoints + (0.25 / AddYds)
                End If

                dgPlayersPlay.Rows.Insert(0, thisTable.Rows(0).Item(2).ToString, pubPlayerStats(iCount).PlayerPoints.ToString, thisTable.Rows(0).Item(7).ToString, thisTable.Rows(0).Item(8).ToString, thisTable.Rows(0).Item(6).ToString)


                'MsgBox(intYardLine.ToString)
                If intYardLine < 0 Then
                    intCalcYardLine = ((((50 + AddYds) + intYardLine) * 8.57) + 205)
                Else
                    intCalcYardLine = (1062 - ((50 - (intYardLine + AddYds)) * 8.57))
                End If
                If InStr(thisTable.Rows(0).Item(6).ToString, "TOUCHDOWN") > 0 Then
                    intCalcYardLine = 1108
                End If

                MoveBall(intCalcYardLine, 51, 0)
                LastDriveID = thisTable.Rows(0).Item(0)
                LastPlayID = thisTable.Rows(0).Item(1)
                lblK.Text = LastDriveID.ToString
                lblDef.Text = LastPlayID.ToString
                lblTE.Text = intCalcYardLine
            Else
                'thisTable.Clear()
                sqlStatement = "select pp.drive_id, pp.play_id, p.full_name, pl.""time"", pl.pos_team, pl.yardline, pl.description, pl.time_inserted, pl.time_updated, pp.* " &
                "from play_player pp " &
                "left join player p on (pp.player_id = p.player_id) " &
                "left join play pl on (pp.gsis_id = pl.gsis_id and pp.play_id = pl.play_id) " &
                "left join game g on (pp.gsis_id = g.gsis_id) " &
                "where pp.gsis_id = '" + pubPlayerStats(iCount).GameID + "' " &
                "and (pp.drive_id >= " & LastDriveID(iCount) & " and pp.drive_id <= " + TextBox1.Text + ") " &
                "and (pp.play_id >= " & LastPlayID(iCount) & " and pp.play_id <= " + TextBox2.Text + ") " &
                "order by pp.drive_id desc, pp.play_id desc " &
                "limit 1"

                thisTable2 = sqlQueryFunction(sqlStatement)
                If thisTable2.Rows.Count > 0 Then
                    If pubPlayerStats(iCount).Team <> thisTable2.Rows(0).Item(4) Then
                        MoveBall(205, 51, 0)
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub MoveBall(ByVal pbX As Decimal, pbY As Decimal, pNumber As Integer)
        'Dim intCalcYardLine As Decimal
        'Dim intOldYardLine As Decimal
        'Dim sqlStatement As String
        'Dim thisTable As DataTable


        'If thisTable.Rows.Count > 0 And thisTable.Rows(0).Item(4) = thisTeam Then
        'If InStr(thisTable.Rows(0).Item(6).ToString, thisTeam) > 0 Then


        'Else

        'End If

        'If thisTable.Rows(0).Item(4) = thisTeam Then
        'intOldYardLine = PictureBox1.Location.X

        'MsgBox(intOldYardLine.ToString)

        'If intCalcYardLine < 0 Then
        'intCalcYardLine = 428.5 - (YdLine * 8.57)
        'Else
        'intCalcYardLine = 1062 - (YdLine * 8.57)
        'End If

        'If Touchdown = True Then
        'intCalcYardLine = 1108
        'End If
        Select Case pNumber
            Case 0
                PictureBox1.Location = New Point(pbX, pbY)
            Case 1
                PictureBox2.Location = New Point(pbX, pbY)
            Case 2
                PictureBox3.Location = New Point(pbX, pbY)
            Case 4
                PictureBox4.Location = New Point(pbX, pbY)
        End Select

        'Else
        'PictureBox1.Location = New Point(205, 51)
        'End If
        'End If
        'lblTE.Text = intCalcYardLine

    End Sub

    Private Sub DrawLine(ByVal oldYardLine As Int64, ByVal newYardLine As Int64, ByVal myPlayer As Boolean, myCount As Integer)
        Dim RedLine As New Pen(Color.Red, 3)
        Dim GreenLine As New Pen(Color.BlueViolet, 3)
        Dim startPoint As New Point(oldYardLine, 51)
        Dim endPoint As New Point(newYardLine, 51)
        'Dim frmGraphics As System.Drawing.Graphics
        Dim myGraphics As Graphics = Me.CreateGraphics
        Dim myPen As Pen

        'frmGraphics = pbField.CreateGraphics
        If myPlayer = True Then
            'frmGraphics.DrawLine(GreenLine, startPoint, endPoint)
            myPen = New Pen(Brushes.DarkMagenta, 5)
            myGraphics.DrawLine(myPen, oldYardLine, BallY(myCount), newYardLine, BallY(myCount))
        Else
            If oldYardLine = 0 And newYardLine = 0 Then
                'pbField.Refresh()
                myPen = New Pen(Brushes.Green, 5)
                myGraphics.DrawLine(myPen, 205, BallY(myCount), 1110, BallY(myCount))
            Else
                'frmGraphics.DrawLine(RedLine, startPoint, endPoint)
                myPen = New Pen(Brushes.Red, 5)
                myGraphics.DrawLine(myPen, oldYardLine, BallY(myCount), newYardLine, BallY(myCount))
            End If
        End If
    End Sub

    Private Sub getPlayersGame(ByVal thisPlayerID As String, ByVal thisID As Integer)
        Dim sqlStatement As String
        Dim thisTable As DataTable



        sqlStatement = "select g.gsis_id " &
                    "from game g " &
                    "left join play_player pp on (g.gsis_id = pp.gsis_id) " &
                    "left join player p on (pp.player_id = p.player_id) " &
                    "where g.season_type = '" + pubMeta.Season + "' and g.season_year = " + pubMeta.Year + " and g.week = " + pubMeta.Week + " and p.player_id = '" + thisPlayerID + "' " &
                    "limit 1"

            thisTable = sqlQueryFunction(sqlStatement)

            If thisTable.Rows.Count > 0 Then
            pubPlayerStats(thisID).GameID = thisTable.Rows(0).Item(0).ToString
        End If

    End Sub

    Private Sub btnPlayers_Click(sender As Object, e As EventArgs) Handles btnPlayers.Click
        'frmPlayerSelect.Show()

        If frmPlayerSelect.ShowDialog = Windows.Forms.DialogResult.OK Then
            For iCount = 0 To 4
                getPlayersGame(pubPlayerStats(iCount).PlayerID, iCount)
            Next

            TextBox1.Text = pubPlayerStats(0).PlayerID
            TextBox2.Text = pubPlayerStats(1).PlayerID

            Timer1.Interval = 15000
            Timer1.Enabled = True
            Timer1.Start()
            'MsgBox("timer set")
        Else

        End If



    End Sub

    Private Sub lblQB_Click(sender As Object, e As EventArgs) Handles lblQB.Click

    End Sub

    Private Sub lblQB_MouseHover(sender As Object, e As EventArgs) Handles lblQB.MouseHover


    End Sub

    Private Sub lblQBPoints_MouseHover(sender As Object, e As EventArgs) Handles lblQBPoints.MouseHover
        Dim tt As New ToolTip

        tt.SetToolTip(lblQB, "Passing Yards " & pubPlayerStats(0).PassingYards & vbCrLf &
                      "Passing TDs " & pubPlayerStats(0).PassingTDs & vbCrLf &
                      "Interceptions " & pubPlayerStats(0).Interceptions)
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub pbField_Click(sender As Object, e As EventArgs) Handles pbField.Click

    End Sub

    Private Sub pbField_Paint(sender As Object, e As PaintEventArgs) Handles pbField.Paint

    End Sub

    Private Sub CreateLiveScoreBox()
        Dim sqlStatement, sStatus, sMeridian As String
        Dim thisTable As DataTable
        Dim iGame, iGrpLoc As Integer
        Dim startTime As DateTime

        sqlStatement = "select home_team, home_score, away_team, away_score, finished, start_time " &
                    "from game " &
                    "where season_type = '" + pubMeta.Season + "' and season_year = " + pubMeta.Year + " and week = " + pubMeta.Week &
                    " order by gsis_id"

        thisTable = sqlQueryFunction(sqlStatement)
        iGame = 0
        iGrpLoc = 36

        If thisTable.Rows.Count > 0 Then
            For iCount = 0 To thisTable.Rows.Count - 1
                If thisTable.Rows(iCount).Item(4).ToString = "1" Then
                    sStatus = "Finished"
                Else
                    startTime = thisTable.Rows(iCount).Item(5).ToString
                    If Hour(startTime) > 12 Then
                        sMeridian = "PM"
                    Else
                        sMeridian = "AM"
                    End If
                    sStatus = Mid(WeekdayName(Weekday(startTime)).ToString, 1, 3) + " @" + Hour(startTime).ToString + sMeridian
                    'sStatus = thisTable.Rows(iCount).Item(5).ToString
                End If
                'Debug.Write("status:" + thisTable.Rows(iCount).Item(4).ToString + " ")
                Dim lblGroup1 As New Label
                Dim lblGroup2 As New Label
                Dim lblGroup3 As New Label
                Dim lblGroup4 As New Label
                Dim lblGroup5 As New Label
                With lblGroup1
                    .Location = New Point(iGrpLoc, 40)
                    .Size = New Size(35, 14)
                    .Font = New Font("Ariel", 8, FontStyle.Bold)
                    .Name = "grpLabelHT" & iCount
                    .Text = thisTable.Rows(iCount).Item(2).ToString
                    .ForeColor = Color.Black
                End With
                With lblGroup2
                    .Size = New Size(35, 14)
                    .Font = New Font("Ariel", 8, FontStyle.Bold)
                    .Location = New Point(iGrpLoc, 55)
                    .Name = "grpLabelAT" & iCount
                    .Text = thisTable.Rows(iCount).Item(0).ToString
                    .ForeColor = Color.Black
                End With
                With lblGroup3
                    .Font = New Font("Ariel", 8, FontStyle.Bold)
                    .Location = New Point(iGrpLoc + 39, 40)
                    .Name = "grpLabelBoxHT" & iCount
                    .Size = New Size(30, 14)
                    .Text = thisTable.Rows(iCount).Item(3).ToString
                    .ForeColor = Color.Black
                End With
                With lblGroup4
                    .Font = New Font("Ariel", 8, FontStyle.Bold)
                    .Location = New Point(iGrpLoc + 39, 55)
                    .Name = "grpLabelBoxAT" & iCount
                    .Text = thisTable.Rows(iCount).Item(1).ToString
                    .Size = New Size(30, 14)
                End With
                With lblGroup5
                    .Font = New Font("Ariel", 6, FontStyle.Bold)
                    .Location = New Point(iGrpLoc, 70)
                    .Name = "grpLabeltStatus" & iCount
                    .Text = sStatus
                    .TextAlign = ContentAlignment.MiddleCenter
                    .Size = New Size(60, 14)
                End With

                Me.Controls.Add(lblGroup1)
                Me.Controls.Add(lblGroup2)
                Me.Controls.Add(lblGroup3)
                Me.Controls.Add(lblGroup4)
                Me.Controls.Add(lblGroup5)

                iGrpLoc += 70
            Next
        End If
    End Sub

    Private Sub updateLiveScores()
        Dim sqlStatement, sStatus, sMeridian As String
        Dim thisTable As DataTable
        Dim iGame, iGrpLoc As Integer
        Dim startTime As DateTime
        'Dim lab1, lab2, lab3, lab4, lab5 As Label

        sqlStatement = "select home_team, home_score, away_team, away_score, finished, start_time " &
                    "from game " &
                    "where season_type = '" + pubMeta.Season + "' and season_year = " + pubMeta.Year + " and week = " + pubMeta.Week &
                    " order by gsis_id"

        thisTable = sqlQueryFunction(sqlStatement)
        iGame = 0
        iGrpLoc = 36

        If thisTable.Rows.Count > 0 Then
            For iCount = 0 To thisTable.Rows.Count - 1
                If thisTable.Rows(iCount).Item(4).ToString = "1" Then
                    sStatus = "Finished"
                Else
                    startTime = thisTable.Rows(iCount).Item(5).ToString
                    If Hour(startTime) > 12 Then
                        sMeridian = "PM"
                    Else
                        sMeridian = "AM"
                    End If
                    sStatus = Mid(WeekdayName(Weekday(startTime)).ToString, 1, 3) + " @" + Hour(startTime).ToString + sMeridian
                End If
                'grpLabelHT+iCount.text = thisTable.Rows(iCount).Item(0).ToString
                Me.Controls("grpLabelHT" & iCount).Text = thisTable.Rows(iCount).Item(2).ToString
                Me.Controls("grpLabelAT" & iCount).Text = thisTable.Rows(iCount).Item(0).ToString
                Me.Controls("grpLabelBoxHT" & iCount).Text = thisTable.Rows(iCount).Item(3).ToString
                Me.Controls("grpLabelBoxAT" & iCount).Text = thisTable.Rows(iCount).Item(1).ToString
                Me.Controls("grpLabeltStatus" & iCount).Text = sStatus

                'Me.Controls("grpLiveScore").Controls("lblAT" & iCount).Text = thisTable.Rows(iCount).Item(2).ToString
                'Me.Controls("grpLiveScore").Controls("lblHT" & iCount).Text = thisTable.Rows(iCount).Item(0).ToString
                'Me.Controls("grpLiveScore").Controls("lblAS" & iCount).Text = thisTable.Rows(iCount).Item(3).ToString
                'Me.Controls("grpLiveScore").Controls("lblHS" & iCount).Text = thisTable.Rows(iCount).Item(1).ToString
                'Me.Controls("grpLiveScore").Controls("lblStat" & iCount).Text = thisTable.Rows(iCount).Item(4).ToString

                'lab2 = Me.Controls("lblHT" & iCount)
                'lab3 = Me.Controls("lblAS" & iCount)
                'lab4 = Me.Controls("lblHS" & iCount)
                'lab5 = Me.Controls("lblStat" & iCount)
                'lab1.Text = thisTable.Rows(iCount).Item(2).ToString
                'lab2.Text = thisTable.Rows(iCount).Item(0).ToString
                'lab3.Text = thisTable.Rows(iCount).Item(3).ToString
                'lab4.Text = thisTable.Rows(iCount).Item(1).ToString
                'lab5.Text = thisTable.Rows(iCount).Item(4).ToString
            Next
        End If

    End Sub

End Class
