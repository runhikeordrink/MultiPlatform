Imports System.Data.Odbc

Public Class frmPlayerSelect
    Dim lblQBselectID As String
    Dim lblRB1selectID As String
    Dim lblRB2selectID As String
    Dim lblWR1selectID As String
    Dim lblWR2selectID As String
    Dim lblWR3selectID As String
    Dim lblTEselectID As String
    Dim lblKselectID As String
    Dim lblDefselectID As String


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
    Private Sub frmPlayerSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        rbAll.Checked = True




    End Sub

    Private Sub rbQB_CheckedChanged(sender As Object, e As EventArgs) Handles rbQB.CheckedChanged
        Dim sqlStatement As String
        Dim thisTable As DataTable
        Dim i As Int16

        sqlStatement = "select player_id, full_name, team, position " &
                    "from player " &
                    "where status = 'Active' and (team <> 'UNK' or position <> 'UNK') and position = 'QB' " &
                    "order by full_name"

        thisTable = sqlQueryFunction(sqlStatement)
        dgViewPlayers.Rows.Clear()
        For Each row As DataRow In thisTable.Rows
            dgViewPlayers.Rows.Add(thisTable.Rows(i).Item(1), thisTable.Rows(i).Item(3), thisTable.Rows(i).Item(2), thisTable.Rows(i).Item(0))
            i = i + 1
        Next
    End Sub

    Private Sub rbRB_CheckedChanged(sender As Object, e As EventArgs) Handles rbRB.CheckedChanged
        Dim sqlStatement As String
        Dim thisTable As DataTable
        Dim i As Int16

        sqlStatement = "select player_id, full_name, team, position " &
                    "from player " &
                    "where status = 'Active' and (team <> 'UNK' or position <> 'UNK') and position in ('RB','FB') " &
                    "order by full_name"

        thisTable = sqlQueryFunction(sqlStatement)
        dgViewPlayers.Rows.Clear()
        For Each row As DataRow In thisTable.Rows
            dgViewPlayers.Rows.Add(thisTable.Rows(i).Item(1), thisTable.Rows(i).Item(3), thisTable.Rows(i).Item(2), thisTable.Rows(i).Item(0))
            i = i + 1
        Next
    End Sub

    Private Sub rbWR_CheckedChanged(sender As Object, e As EventArgs) Handles rbWR.CheckedChanged
        Dim sqlStatement As String
        Dim thisTable As DataTable
        Dim i As Int16

        sqlStatement = "select player_id, full_name, team, position " &
                    "from player " &
                    "where status = 'Active' and (team <> 'UNK' or position <> 'UNK') and position = 'WR' " &
                    "order by full_name"

        thisTable = sqlQueryFunction(sqlStatement)
        dgViewPlayers.Rows.Clear()
        For Each row As DataRow In thisTable.Rows
            dgViewPlayers.Rows.Add(thisTable.Rows(i).Item(1), thisTable.Rows(i).Item(3), thisTable.Rows(i).Item(2), thisTable.Rows(i).Item(0))
            i = i + 1
        Next
    End Sub

    Private Sub rbTE_CheckedChanged(sender As Object, e As EventArgs) Handles rbTE.CheckedChanged
        Dim sqlStatement As String
        Dim thisTable As DataTable
        Dim i As Int16

        sqlStatement = "select player_id, full_name, team, position " &
                    "from player " &
                    "where status = 'Active' and (team <> 'UNK' or position <> 'UNK') and position = 'TE' " &
                    "order by full_name"

        thisTable = sqlQueryFunction(sqlStatement)
        dgViewPlayers.Rows.Clear()
        For Each row As DataRow In thisTable.Rows
            dgViewPlayers.Rows.Add(thisTable.Rows(i).Item(1), thisTable.Rows(i).Item(3), thisTable.Rows(i).Item(2), thisTable.Rows(i).Item(0))
            i = i + 1
        Next
    End Sub

    Private Sub rbK_CheckedChanged(sender As Object, e As EventArgs) Handles rbK.CheckedChanged
        Dim sqlStatement As String
        Dim thisTable As DataTable
        Dim i As Int16

        sqlStatement = "select player_id, full_name, team, position " &
                    "from player " &
                    "where status = 'Active' and (team <> 'UNK' or position <> 'UNK') and position = 'K' " &
                    "order by full_name"

        thisTable = sqlQueryFunction(sqlStatement)
        dgViewPlayers.Rows.Clear()
        For Each row As DataRow In thisTable.Rows
            dgViewPlayers.Rows.Add(thisTable.Rows(i).Item(1), thisTable.Rows(i).Item(3), thisTable.Rows(i).Item(2), thisTable.Rows(i).Item(0))
            i = i + 1
        Next
    End Sub

    Private Sub rbAll_CheckedChanged(sender As Object, e As EventArgs) Handles rbAll.CheckedChanged
        Dim sqlStatement As String
        Dim thisTable As DataTable
        Dim i As Int16

        sqlStatement = "select player_id, full_name, team, position " &
                    "from player " &
                    "where status = 'Active' and (team <> 'UNK' or position <> 'UNK') and position in ('QB','RB','FB','WR','TE','K') " &
                    "order by full_name"

        thisTable = sqlQueryFunction(sqlStatement)
        i = 0
        dgViewPlayers.Rows.Clear()
        For Each row As DataRow In thisTable.Rows
            dgViewPlayers.Rows.Add(thisTable.Rows(i).Item(1), thisTable.Rows(i).Item(3), thisTable.Rows(i).Item(2), thisTable.Rows(i).Item(0))
            i = i + 1
        Next
    End Sub

    Private Sub lblQBSelection_Click(sender As Object, e As EventArgs) Handles lblQBSelection.Click
        lblQBSelection.Text = "(QB)-" + dgViewPlayers.Item(0, dgViewPlayers.CurrentRow.Index).Value
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Dim playerID As String
        Dim playerTeam As String

        'If lblQBSelection.Text <> "Quarterback" And lblRB1Selection.Text <> "RunningBack1" And lblRB2Selection.Text <> "RunningBack2" And lblWR1Selection.Text <> "WideRec1" And lblWR2Selection.Text <> "WideRec2" And lblWR3Selection.Text <> "WideRec3" And lblTESelection.Text <> "TightEnd" And lblKSelection.Text <> "Kicker" Then
        playerID = dgViewPlayers.Item(3, dgViewPlayers.CurrentRow.Index).Value
        playerTeam = dgViewPlayers.Item(2, dgViewPlayers.CurrentRow.Index).Value

        frmDPv2.pubPlayerStats(0).PlayerID = lblQBselectID
        frmDPv2.pubPlayerStats(0).Team = playerTeam
        frmDPv2.lblQB.Text = lblQBSelection.Text

        frmDPv2.pubPlayerStats(1).PlayerID = lblRB1selectID
        frmDPv2.pubPlayerStats(1).Team = playerTeam
        frmDPv2.lblRB1.Text = lblRB1Selection.Text

        frmDPv2.pubPlayerStats(2).PlayerID = lblRB2selectID
        frmDPv2.pubPlayerStats(2).Team = playerTeam
        frmDPv2.lblRB2.Text = lblRB2Selection.Text

        frmDPv2.pubPlayerStats(3).PlayerID = lblWR1selectID
        frmDPv2.pubPlayerStats(3).Team = playerTeam
        frmDPv2.lblWR1.Text = lblWR1Selection.Text

        frmDPv2.pubPlayerStats(4).PlayerID = lblWR2selectID
        frmDPv2.pubPlayerStats(4).Team = playerTeam
        frmDPv2.lblWR2.Text = lblWR2Selection.Text

        frmDPv2.lblWR3.Text = lblWR3Selection.Text
        frmDPv2.lblTE.Text = lblTESelection.Text
        frmDPv2.lblK.Text = lblKSelection.Text

        Me.Close()
        'else
        'msgbox("not all fields filled in")
        'End If        

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub dgViewPlayers_AutoSizeColumnModeChanged(sender As Object, e As DataGridViewAutoSizeColumnModeEventArgs) Handles dgViewPlayers.AutoSizeColumnModeChanged

    End Sub

    Private Sub dgViewPlayers_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgViewPlayers.CellDoubleClick
        Select Case dgViewPlayers.Item(1, dgViewPlayers.CurrentRow.Index).Value
            Case "QB"
                If lblQBSelection.Text = "Quarterback" Then
                    lblQBSelection.Text = "(QB)-" + dgViewPlayers.Item(0, dgViewPlayers.CurrentRow.Index).Value
                    lblQBselectID = dgViewPlayers.Item(3, dgViewPlayers.CurrentRow.Index).Value.ToString
                End If
            Case "RB"
                If lblRB1Selection.Text = "RunningBack1" Then
                    lblRB1Selection.Text = "(RB)-" + dgViewPlayers.Item(0, dgViewPlayers.CurrentRow.Index).Value
                    lblRB1selectID = dgViewPlayers.Item(3, dgViewPlayers.CurrentRow.Index).Value.ToString
                ElseIf lblRB2Selection.Text = "RunningBack2" Then
                    lblRB2selectID = dgViewPlayers.Item(3, dgViewPlayers.CurrentRow.Index).Value.ToString
                    lblRB2Selection.Text = "(RB)-" + dgViewPlayers.Item(0, dgViewPlayers.CurrentRow.Index).Value
                End If
            Case "WR"
                If lblWR1Selection.Text = "WideRec1" Then
                    lblWR1selectID = dgViewPlayers.Item(3, dgViewPlayers.CurrentRow.Index).Value.ToString
                    lblWR1Selection.Text = "(WR)-" + dgViewPlayers.Item(0, dgViewPlayers.CurrentRow.Index).Value
                ElseIf lblWR2Selection.Text = "WideRec2" Then
                    lblRB2selectID = dgViewPlayers.Item(3, dgViewPlayers.CurrentRow.Index).Value.ToString
                    lblWR2Selection.Text = "(WR)-" + dgViewPlayers.Item(0, dgViewPlayers.CurrentRow.Index).Value
                ElseIf lblWR3Selection.Text = "WideRec3" Then
                    lblWR3selectID = dgViewPlayers.Item(3, dgViewPlayers.CurrentRow.Index).Value.ToString
                    lblWR3Selection.Text = "(WR)-" + dgViewPlayers.Item(0, dgViewPlayers.CurrentRow.Index).Value
                End If
            Case "TE"
                If lblTESelection.Text = "TightEnd" Then
                    lblTEselectID = dgViewPlayers.Item(3, dgViewPlayers.CurrentRow.Index).Value.ToString
                    lblTESelection.Text = "(TE)-" + dgViewPlayers.Item(0, dgViewPlayers.CurrentRow.Index).Value
                End If
            Case "K"
                If lblKSelection.Text = "Kicker" Then
                    lblKselectID = dgViewPlayers.Item(3, dgViewPlayers.CurrentRow.Index).Value.ToString
                    lblKSelection.Text = "(K)-" + dgViewPlayers.Item(0, dgViewPlayers.CurrentRow.Index).Value
                End If
        End Select

        'If dgViewPlayers.Item(1, dgViewPlayers.CurrentRow.Index).Value = "QB" Then
        'lblQBSelection.Text = dgViewPlayers.Item(0, dgViewPlayers.CurrentRow.Index).Value

        'End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        lblQBSelection.Text = "Quarterback"
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        lblRB1Selection.Text = "RunningBack1"
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        lblRB2Selection.Text = "RunningBack2"
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        lblWR1Selection.Text = "WideRec1"
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        lblWR2Selection.Text = "WideRec2"
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        lblWR3Selection.Text = "WideRec3"
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        lblTESelection.Text = "TightEnd"
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        lblKSelection.Text = "Kicker"
    End Sub

    Private Sub lblRB1Selection_Click(sender As Object, e As EventArgs) Handles lblRB1Selection.Click
        lblRB1Selection.Text = "(RB)-" + dgViewPlayers.Item(0, dgViewPlayers.CurrentRow.Index).Value
    End Sub

    Private Sub lblRB2Selection_Click(sender As Object, e As EventArgs) Handles lblRB2Selection.Click
        lblRB2Selection.Text = "(RB)-" + dgViewPlayers.Item(0, dgViewPlayers.CurrentRow.Index).Value
    End Sub

    Private Sub lblWR1Selection_Click(sender As Object, e As EventArgs) Handles lblWR1Selection.Click
        lblWR1Selection.Text = "(WR)-" + dgViewPlayers.Item(0, dgViewPlayers.CurrentRow.Index).Value
    End Sub

    Private Sub lblWR2Selection_Click(sender As Object, e As EventArgs) Handles lblWR2Selection.Click
        lblWR2Selection.Text = "(WR)-" + dgViewPlayers.Item(0, dgViewPlayers.CurrentRow.Index).Value
    End Sub

    Private Sub lblWR3Selection_Click(sender As Object, e As EventArgs) Handles lblWR3Selection.Click
        lblWR3Selection.Text = "(WR)-" + dgViewPlayers.Item(0, dgViewPlayers.CurrentRow.Index).Value
    End Sub

    Private Sub lblTESelection_Click(sender As Object, e As EventArgs) Handles lblTESelection.Click
        lblTESelection.Text = "(TE)-" + dgViewPlayers.Item(0, dgViewPlayers.CurrentRow.Index).Value
    End Sub

    Private Sub lblKSelection_Click(sender As Object, e As EventArgs) Handles lblKSelection.Click
        lblKSelection.Text = "(K)-" + dgViewPlayers.Item(0, dgViewPlayers.CurrentRow.Index).Value
    End Sub
End Class