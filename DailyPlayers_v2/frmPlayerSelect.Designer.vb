<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlayerSelect
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlayerSelect))
        Me.grpPosition = New System.Windows.Forms.GroupBox()
        Me.rbDef = New System.Windows.Forms.RadioButton()
        Me.rbK = New System.Windows.Forms.RadioButton()
        Me.rbTE = New System.Windows.Forms.RadioButton()
        Me.rbWR = New System.Windows.Forms.RadioButton()
        Me.rbRB = New System.Windows.Forms.RadioButton()
        Me.rbQB = New System.Windows.Forms.RadioButton()
        Me.rbAll = New System.Windows.Forms.RadioButton()
        Me.dgViewPlayers = New System.Windows.Forms.DataGridView()
        Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPosition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTeam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPlayerID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DsNFLdbBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsNFLdb = New DailyPlayers_v2.dsNFLdb()
        Me.lblQBSelection = New System.Windows.Forms.Label()
        Me.lblRB1Selection = New System.Windows.Forms.Label()
        Me.lblRB2Selection = New System.Windows.Forms.Label()
        Me.lblWR1Selection = New System.Windows.Forms.Label()
        Me.lblWR2Selection = New System.Windows.Forms.Label()
        Me.lblWR3Selection = New System.Windows.Forms.Label()
        Me.lblTESelection = New System.Windows.Forms.Label()
        Me.lblKSelection = New System.Windows.Forms.Label()
        Me.lblDefSelection = New System.Windows.Forms.Label()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.grpPosition.SuspendLayout()
        CType(Me.dgViewPlayers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsNFLdbBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsNFLdb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpPosition
        '
        Me.grpPosition.Controls.Add(Me.rbDef)
        Me.grpPosition.Controls.Add(Me.rbK)
        Me.grpPosition.Controls.Add(Me.rbTE)
        Me.grpPosition.Controls.Add(Me.rbWR)
        Me.grpPosition.Controls.Add(Me.rbRB)
        Me.grpPosition.Controls.Add(Me.rbQB)
        Me.grpPosition.Controls.Add(Me.rbAll)
        Me.grpPosition.Location = New System.Drawing.Point(13, 13)
        Me.grpPosition.Name = "grpPosition"
        Me.grpPosition.Size = New System.Drawing.Size(330, 49)
        Me.grpPosition.TabIndex = 0
        Me.grpPosition.TabStop = False
        Me.grpPosition.Text = "Position"
        '
        'rbDef
        '
        Me.rbDef.AutoSize = True
        Me.rbDef.Location = New System.Drawing.Point(280, 20)
        Me.rbDef.Name = "rbDef"
        Me.rbDef.Size = New System.Drawing.Size(42, 17)
        Me.rbDef.TabIndex = 6
        Me.rbDef.Text = "Def"
        Me.rbDef.UseVisualStyleBackColor = True
        '
        'rbK
        '
        Me.rbK.AutoSize = True
        Me.rbK.Location = New System.Drawing.Point(241, 20)
        Me.rbK.Name = "rbK"
        Me.rbK.Size = New System.Drawing.Size(32, 17)
        Me.rbK.TabIndex = 5
        Me.rbK.Text = "K"
        Me.rbK.UseVisualStyleBackColor = True
        '
        'rbTE
        '
        Me.rbTE.AutoSize = True
        Me.rbTE.Location = New System.Drawing.Point(195, 20)
        Me.rbTE.Name = "rbTE"
        Me.rbTE.Size = New System.Drawing.Size(39, 17)
        Me.rbTE.TabIndex = 4
        Me.rbTE.Text = "TE"
        Me.rbTE.UseVisualStyleBackColor = True
        '
        'rbWR
        '
        Me.rbWR.AutoSize = True
        Me.rbWR.Location = New System.Drawing.Point(144, 20)
        Me.rbWR.Name = "rbWR"
        Me.rbWR.Size = New System.Drawing.Size(44, 17)
        Me.rbWR.TabIndex = 3
        Me.rbWR.Text = "WR"
        Me.rbWR.UseVisualStyleBackColor = True
        '
        'rbRB
        '
        Me.rbRB.AutoSize = True
        Me.rbRB.Location = New System.Drawing.Point(97, 20)
        Me.rbRB.Name = "rbRB"
        Me.rbRB.Size = New System.Drawing.Size(40, 17)
        Me.rbRB.TabIndex = 2
        Me.rbRB.Text = "RB"
        Me.rbRB.UseVisualStyleBackColor = True
        '
        'rbQB
        '
        Me.rbQB.AutoSize = True
        Me.rbQB.Location = New System.Drawing.Point(50, 20)
        Me.rbQB.Name = "rbQB"
        Me.rbQB.Size = New System.Drawing.Size(40, 17)
        Me.rbQB.TabIndex = 1
        Me.rbQB.Text = "QB"
        Me.rbQB.UseVisualStyleBackColor = True
        '
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.Location = New System.Drawing.Point(7, 20)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(36, 17)
        Me.rbAll.TabIndex = 0
        Me.rbAll.Text = "All"
        Me.rbAll.UseVisualStyleBackColor = True
        '
        'dgViewPlayers
        '
        Me.dgViewPlayers.AllowUserToAddRows = False
        Me.dgViewPlayers.AllowUserToDeleteRows = False
        Me.dgViewPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgViewPlayers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colName, Me.colPosition, Me.colTeam, Me.colPlayerID})
        Me.dgViewPlayers.Location = New System.Drawing.Point(13, 69)
        Me.dgViewPlayers.Name = "dgViewPlayers"
        Me.dgViewPlayers.ReadOnly = True
        Me.dgViewPlayers.Size = New System.Drawing.Size(330, 571)
        Me.dgViewPlayers.TabIndex = 1
        '
        'colName
        '
        Me.colName.HeaderText = "Name"
        Me.colName.Name = "colName"
        Me.colName.ReadOnly = True
        '
        'colPosition
        '
        Me.colPosition.HeaderText = "Position"
        Me.colPosition.Name = "colPosition"
        Me.colPosition.ReadOnly = True
        '
        'colTeam
        '
        Me.colTeam.HeaderText = "Team"
        Me.colTeam.Name = "colTeam"
        Me.colTeam.ReadOnly = True
        '
        'colPlayerID
        '
        Me.colPlayerID.HeaderText = "PlayerID"
        Me.colPlayerID.Name = "colPlayerID"
        Me.colPlayerID.ReadOnly = True
        Me.colPlayerID.Visible = False
        '
        'DsNFLdbBindingSource
        '
        Me.DsNFLdbBindingSource.DataSource = Me.DsNFLdb
        Me.DsNFLdbBindingSource.Position = 0
        '
        'DsNFLdb
        '
        Me.DsNFLdb.DataSetName = "dsNFLdb"
        Me.DsNFLdb.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lblQBSelection
        '
        Me.lblQBSelection.AutoSize = True
        Me.lblQBSelection.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblQBSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQBSelection.Location = New System.Drawing.Point(374, 127)
        Me.lblQBSelection.Name = "lblQBSelection"
        Me.lblQBSelection.Size = New System.Drawing.Size(97, 20)
        Me.lblQBSelection.TabIndex = 2
        Me.lblQBSelection.Text = "Quarterback"
        '
        'lblRB1Selection
        '
        Me.lblRB1Selection.AutoSize = True
        Me.lblRB1Selection.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblRB1Selection.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRB1Selection.Location = New System.Drawing.Point(374, 167)
        Me.lblRB1Selection.Name = "lblRB1Selection"
        Me.lblRB1Selection.Size = New System.Drawing.Size(114, 20)
        Me.lblRB1Selection.TabIndex = 3
        Me.lblRB1Selection.Text = "RunningBack1"
        '
        'lblRB2Selection
        '
        Me.lblRB2Selection.AutoSize = True
        Me.lblRB2Selection.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblRB2Selection.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRB2Selection.Location = New System.Drawing.Point(374, 209)
        Me.lblRB2Selection.Name = "lblRB2Selection"
        Me.lblRB2Selection.Size = New System.Drawing.Size(114, 20)
        Me.lblRB2Selection.TabIndex = 4
        Me.lblRB2Selection.Text = "RunningBack2"
        '
        'lblWR1Selection
        '
        Me.lblWR1Selection.AutoSize = True
        Me.lblWR1Selection.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblWR1Selection.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWR1Selection.Location = New System.Drawing.Point(374, 249)
        Me.lblWR1Selection.Name = "lblWR1Selection"
        Me.lblWR1Selection.Size = New System.Drawing.Size(83, 20)
        Me.lblWR1Selection.TabIndex = 5
        Me.lblWR1Selection.Text = "WideRec1"
        '
        'lblWR2Selection
        '
        Me.lblWR2Selection.AutoSize = True
        Me.lblWR2Selection.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblWR2Selection.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWR2Selection.Location = New System.Drawing.Point(374, 291)
        Me.lblWR2Selection.Name = "lblWR2Selection"
        Me.lblWR2Selection.Size = New System.Drawing.Size(83, 20)
        Me.lblWR2Selection.TabIndex = 6
        Me.lblWR2Selection.Text = "WideRec2"
        '
        'lblWR3Selection
        '
        Me.lblWR3Selection.AutoSize = True
        Me.lblWR3Selection.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblWR3Selection.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWR3Selection.Location = New System.Drawing.Point(374, 331)
        Me.lblWR3Selection.Name = "lblWR3Selection"
        Me.lblWR3Selection.Size = New System.Drawing.Size(83, 20)
        Me.lblWR3Selection.TabIndex = 7
        Me.lblWR3Selection.Text = "WideRec3"
        '
        'lblTESelection
        '
        Me.lblTESelection.AutoSize = True
        Me.lblTESelection.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTESelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTESelection.Location = New System.Drawing.Point(374, 373)
        Me.lblTESelection.Name = "lblTESelection"
        Me.lblTESelection.Size = New System.Drawing.Size(73, 20)
        Me.lblTESelection.TabIndex = 8
        Me.lblTESelection.Text = "TightEnd"
        '
        'lblKSelection
        '
        Me.lblKSelection.AutoSize = True
        Me.lblKSelection.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblKSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKSelection.Location = New System.Drawing.Point(374, 413)
        Me.lblKSelection.Name = "lblKSelection"
        Me.lblKSelection.Size = New System.Drawing.Size(52, 20)
        Me.lblKSelection.TabIndex = 9
        Me.lblKSelection.Text = "Kicker"
        '
        'lblDefSelection
        '
        Me.lblDefSelection.AutoSize = True
        Me.lblDefSelection.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblDefSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefSelection.Location = New System.Drawing.Point(374, 451)
        Me.lblDefSelection.Name = "lblDefSelection"
        Me.lblDefSelection.Size = New System.Drawing.Size(70, 20)
        Me.lblDefSelection.TabIndex = 10
        Me.lblDefSelection.Text = "Defense"
        '
        'btnSelect
        '
        Me.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSelect.Location = New System.Drawing.Point(354, 616)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 23)
        Me.btnSelect.TabIndex = 11
        Me.btnSelect.Text = "Select"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(458, 615)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(356, 127)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(12, 12)
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(356, 167)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(12, 12)
        Me.PictureBox2.TabIndex = 14
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(356, 249)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(12, 12)
        Me.PictureBox3.TabIndex = 16
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(356, 209)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(12, 12)
        Me.PictureBox4.TabIndex = 15
        Me.PictureBox4.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(356, 413)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(12, 12)
        Me.PictureBox5.TabIndex = 20
        Me.PictureBox5.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(356, 373)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(12, 12)
        Me.PictureBox6.TabIndex = 19
        Me.PictureBox6.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(356, 331)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(12, 12)
        Me.PictureBox7.TabIndex = 18
        Me.PictureBox7.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(356, 291)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(12, 12)
        Me.PictureBox8.TabIndex = 17
        Me.PictureBox8.TabStop = False
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(356, 451)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(12, 12)
        Me.PictureBox9.TabIndex = 21
        Me.PictureBox9.TabStop = False
        '
        'frmPlayerSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(573, 709)
        Me.Controls.Add(Me.PictureBox9)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.lblDefSelection)
        Me.Controls.Add(Me.lblKSelection)
        Me.Controls.Add(Me.lblTESelection)
        Me.Controls.Add(Me.lblWR3Selection)
        Me.Controls.Add(Me.lblWR2Selection)
        Me.Controls.Add(Me.lblWR1Selection)
        Me.Controls.Add(Me.lblRB2Selection)
        Me.Controls.Add(Me.lblRB1Selection)
        Me.Controls.Add(Me.lblQBSelection)
        Me.Controls.Add(Me.dgViewPlayers)
        Me.Controls.Add(Me.grpPosition)
        Me.Name = "frmPlayerSelect"
        Me.Text = "Select Players"
        Me.grpPosition.ResumeLayout(False)
        Me.grpPosition.PerformLayout()
        CType(Me.dgViewPlayers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsNFLdbBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsNFLdb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpPosition As System.Windows.Forms.GroupBox
    Friend WithEvents rbDef As System.Windows.Forms.RadioButton
    Friend WithEvents rbK As System.Windows.Forms.RadioButton
    Friend WithEvents rbTE As System.Windows.Forms.RadioButton
    Friend WithEvents rbWR As System.Windows.Forms.RadioButton
    Friend WithEvents rbRB As System.Windows.Forms.RadioButton
    Friend WithEvents rbQB As System.Windows.Forms.RadioButton
    Friend WithEvents rbAll As System.Windows.Forms.RadioButton
    Friend WithEvents dgViewPlayers As System.Windows.Forms.DataGridView
    Friend WithEvents DsNFLdbBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsNFLdb As DailyPlayers_v2.dsNFLdb
    Friend WithEvents lblQBSelection As System.Windows.Forms.Label
    Friend WithEvents lblRB1Selection As System.Windows.Forms.Label
    Friend WithEvents lblRB2Selection As System.Windows.Forms.Label
    Friend WithEvents lblWR1Selection As System.Windows.Forms.Label
    Friend WithEvents lblWR2Selection As System.Windows.Forms.Label
    Friend WithEvents lblWR3Selection As System.Windows.Forms.Label
    Friend WithEvents lblTESelection As System.Windows.Forms.Label
    Friend WithEvents lblKSelection As System.Windows.Forms.Label
    Friend WithEvents lblDefSelection As System.Windows.Forms.Label
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents colName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPosition As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTeam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPlayerID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
End Class
