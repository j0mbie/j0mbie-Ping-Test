<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlTab
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgResults = New System.Windows.Forms.DataGridView()
        Me.colNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColHost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLatency = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblTimeout = New System.Windows.Forms.Label()
        Me.txtTimeout = New System.Windows.Forms.TextBox()
        Me.txtDelay = New System.Windows.Forms.TextBox()
        Me.lblOutputPath = New System.Windows.Forms.Label()
        Me.lblDelay = New System.Windows.Forms.Label()
        Me.chkAutoscroll = New System.Windows.Forms.CheckBox()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnResume = New System.Windows.Forms.Button()
        Me.txtHost = New System.Windows.Forms.TextBox()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnPause = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.ssPingStats = New System.Windows.Forms.StatusStrip()
        Me.tsslTotalPings = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslAverageTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslMinTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslMaxTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslTotalLost = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslPercentageLost = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssPingStats.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgResults
        '
        Me.dgResults.AllowUserToAddRows = False
        Me.dgResults.AllowUserToDeleteRows = False
        Me.dgResults.AllowUserToOrderColumns = True
        Me.dgResults.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.dgResults.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgResults.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgResults.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgResults.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNumber, Me.ColHost, Me.colDateTime, Me.colLatency, Me.colStatus})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgResults.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgResults.Location = New System.Drawing.Point(4, 36)
        Me.dgResults.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dgResults.Name = "dgResults"
        Me.dgResults.ReadOnly = True
        Me.dgResults.RowHeadersVisible = False
        Me.dgResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgResults.Size = New System.Drawing.Size(762, 230)
        Me.dgResults.TabIndex = 37
        Me.dgResults.TabStop = False
        Me.dgResults.Tag = ""
        '
        'colNumber
        '
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colNumber.DefaultCellStyle = DataGridViewCellStyle3
        Me.colNumber.FillWeight = 20.0!
        Me.colNumber.HeaderText = "Number"
        Me.colNumber.Name = "colNumber"
        Me.colNumber.ReadOnly = True
        '
        'ColHost
        '
        Me.ColHost.FillWeight = 50.0!
        Me.ColHost.HeaderText = "Host"
        Me.ColHost.Name = "ColHost"
        Me.ColHost.ReadOnly = True
        '
        'colDateTime
        '
        Me.colDateTime.FillWeight = 50.0!
        Me.colDateTime.HeaderText = "Date and Time"
        Me.colDateTime.Name = "colDateTime"
        Me.colDateTime.ReadOnly = True
        '
        'colLatency
        '
        Me.colLatency.FillWeight = 20.0!
        Me.colLatency.HeaderText = "Latency"
        Me.colLatency.Name = "colLatency"
        Me.colLatency.ReadOnly = True
        '
        'colStatus
        '
        Me.colStatus.HeaderText = "Status"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.ReadOnly = True
        '
        'lblTimeout
        '
        Me.lblTimeout.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTimeout.AutoSize = True
        Me.lblTimeout.Location = New System.Drawing.Point(94, 274)
        Me.lblTimeout.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTimeout.Name = "lblTimeout"
        Me.lblTimeout.Size = New System.Drawing.Size(78, 15)
        Me.lblTimeout.TabIndex = 36
        Me.lblTimeout.Text = "Timeout (ms)"
        '
        'txtTimeout
        '
        Me.txtTimeout.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTimeout.Location = New System.Drawing.Point(94, 292)
        Me.txtTimeout.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtTimeout.Name = "txtTimeout"
        Me.txtTimeout.Size = New System.Drawing.Size(82, 23)
        Me.txtTimeout.TabIndex = 8
        Me.txtTimeout.Text = "5000"
        '
        'txtDelay
        '
        Me.txtDelay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDelay.Location = New System.Drawing.Point(4, 292)
        Me.txtDelay.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtDelay.Name = "txtDelay"
        Me.txtDelay.Size = New System.Drawing.Size(82, 23)
        Me.txtDelay.TabIndex = 7
        Me.txtDelay.Text = "2000"
        '
        'lblOutputPath
        '
        Me.lblOutputPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblOutputPath.AutoSize = True
        Me.lblOutputPath.Location = New System.Drawing.Point(186, 274)
        Me.lblOutputPath.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOutputPath.Name = "lblOutputPath"
        Me.lblOutputPath.Size = New System.Drawing.Size(285, 15)
        Me.lblOutputPath.TabIndex = 34
        Me.lblOutputPath.Text = "Output path (filename will auto-generate upon start)"
        '
        'lblDelay
        '
        Me.lblDelay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDelay.AutoSize = True
        Me.lblDelay.Location = New System.Drawing.Point(4, 274)
        Me.lblDelay.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDelay.Name = "lblDelay"
        Me.lblDelay.Size = New System.Drawing.Size(63, 15)
        Me.lblDelay.TabIndex = 33
        Me.lblDelay.Text = "Delay (ms)"
        '
        'chkAutoscroll
        '
        Me.chkAutoscroll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkAutoscroll.AutoSize = True
        Me.chkAutoscroll.Checked = True
        Me.chkAutoscroll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAutoscroll.Location = New System.Drawing.Point(688, 6)
        Me.chkAutoscroll.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkAutoscroll.Name = "chkAutoscroll"
        Me.chkAutoscroll.Size = New System.Drawing.Size(86, 19)
        Me.chkAutoscroll.TabIndex = 6
        Me.chkAutoscroll.Text = "Auto-Scroll"
        Me.chkAutoscroll.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPath.Location = New System.Drawing.Point(184, 292)
        Me.txtPath.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(490, 23)
        Me.txtPath.TabIndex = 35
        Me.txtPath.TabStop = False
        Me.txtPath.Text = "C:\Data\Ping Results\"
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.Location = New System.Drawing.Point(678, 289)
        Me.btnBrowse.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(88, 27)
        Me.btnBrowse.TabIndex = 9
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnResume
        '
        Me.btnResume.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnResume.Enabled = False
        Me.btnResume.Location = New System.Drawing.Point(496, 3)
        Me.btnResume.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnResume.Name = "btnResume"
        Me.btnResume.Size = New System.Drawing.Size(88, 27)
        Me.btnResume.TabIndex = 4
        Me.btnResume.Text = "Resume"
        Me.btnResume.UseVisualStyleBackColor = True
        '
        'txtHost
        '
        Me.txtHost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHost.ForeColor = System.Drawing.Color.Gray
        Me.txtHost.Location = New System.Drawing.Point(4, 5)
        Me.txtHost.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(292, 23)
        Me.txtHost.TabIndex = 1
        Me.txtHost.Text = "Hostname or IP Address"
        '
        'btnStop
        '
        Me.btnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStop.Enabled = False
        Me.btnStop.Location = New System.Drawing.Point(592, 3)
        Me.btnStop.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(88, 27)
        Me.btnStop.TabIndex = 5
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnPause
        '
        Me.btnPause.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPause.Enabled = False
        Me.btnPause.Location = New System.Drawing.Point(400, 3)
        Me.btnPause.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.Size = New System.Drawing.Size(88, 27)
        Me.btnPause.TabIndex = 3
        Me.btnPause.Text = "Pause"
        Me.btnPause.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart.Location = New System.Drawing.Point(304, 3)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(88, 27)
        Me.btnStart.TabIndex = 2
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'ssPingStats
        '
        Me.ssPingStats.AllowMerge = False
        Me.ssPingStats.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ssPingStats.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ssPingStats.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslTotalPings, Me.tsslAverageTime, Me.tsslMinTime, Me.tsslMaxTime, Me.tsslTotalLost, Me.tsslPercentageLost})
        Me.ssPingStats.Location = New System.Drawing.Point(0, 319)
        Me.ssPingStats.Name = "ssPingStats"
        Me.ssPingStats.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ssPingStats.Size = New System.Drawing.Size(774, 22)
        Me.ssPingStats.SizingGrip = False
        Me.ssPingStats.TabIndex = 50
        Me.ssPingStats.Text = "StatusStrip1"
        '
        'tsslTotalPings
        '
        Me.tsslTotalPings.Name = "tsslTotalPings"
        Me.tsslTotalPings.Size = New System.Drawing.Size(121, 17)
        Me.tsslTotalPings.Spring = True
        Me.tsslTotalPings.Text = "Total Pings: 0"
        '
        'tsslAverageTime
        '
        Me.tsslAverageTime.Name = "tsslAverageTime"
        Me.tsslAverageTime.Size = New System.Drawing.Size(121, 17)
        Me.tsslAverageTime.Spring = True
        Me.tsslAverageTime.Text = "Average Time: --"
        '
        'tsslMinTime
        '
        Me.tsslMinTime.Name = "tsslMinTime"
        Me.tsslMinTime.Size = New System.Drawing.Size(121, 17)
        Me.tsslMinTime.Spring = True
        Me.tsslMinTime.Text = "Min. Time: --"
        '
        'tsslMaxTime
        '
        Me.tsslMaxTime.Name = "tsslMaxTime"
        Me.tsslMaxTime.Size = New System.Drawing.Size(121, 17)
        Me.tsslMaxTime.Spring = True
        Me.tsslMaxTime.Text = "Max. Time: --"
        '
        'tsslTotalLost
        '
        Me.tsslTotalLost.Name = "tsslTotalLost"
        Me.tsslTotalLost.Size = New System.Drawing.Size(121, 17)
        Me.tsslTotalLost.Spring = True
        Me.tsslTotalLost.Text = "Total Lost: --"
        '
        'tsslPercentageLost
        '
        Me.tsslPercentageLost.Name = "tsslPercentageLost"
        Me.tsslPercentageLost.Size = New System.Drawing.Size(121, 17)
        Me.tsslPercentageLost.Spring = True
        Me.tsslPercentageLost.Text = "Percentage Lost: --"
        '
        'ctrlTab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.dgResults)
        Me.Controls.Add(Me.ssPingStats)
        Me.Controls.Add(Me.txtTimeout)
        Me.Controls.Add(Me.txtDelay)
        Me.Controls.Add(Me.chkAutoscroll)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.btnResume)
        Me.Controls.Add(Me.txtHost)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnPause)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.lblTimeout)
        Me.Controls.Add(Me.lblDelay)
        Me.Controls.Add(Me.lblOutputPath)
        Me.Name = "ctrlTab"
        Me.Size = New System.Drawing.Size(774, 341)
        Me.Tag = ""
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssPingStats.ResumeLayout(False)
        Me.ssPingStats.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTimeout As Label
    Friend WithEvents txtTimeout As TextBox
    Friend WithEvents txtDelay As TextBox
    Friend WithEvents lblOutputPath As Label
    Friend WithEvents lblDelay As Label
    Friend WithEvents chkAutoscroll As CheckBox
    Friend WithEvents txtPath As TextBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents btnResume As Button
    Friend WithEvents txtHost As TextBox
    Friend WithEvents btnStop As Button
    Friend WithEvents btnPause As Button
    Friend WithEvents FolderBrowserDialog As FolderBrowserDialog
    Public WithEvents btnStart As Button
    Public WithEvents dgResults As DataGridView
    Friend WithEvents ssPingStats As StatusStrip
    Friend WithEvents tsslTotalPings As ToolStripStatusLabel
    Friend WithEvents tsslAverageTime As ToolStripStatusLabel
    Friend WithEvents tsslMinTime As ToolStripStatusLabel
    Friend WithEvents tsslMaxTime As ToolStripStatusLabel
    Friend WithEvents tsslTotalLost As ToolStripStatusLabel
    Friend WithEvents tsslPercentageLost As ToolStripStatusLabel
    Friend WithEvents colNumber As DataGridViewTextBoxColumn
    Friend WithEvents ColHost As DataGridViewTextBoxColumn
    Friend WithEvents colDateTime As DataGridViewTextBoxColumn
    Friend WithEvents colLatency As DataGridViewTextBoxColumn
    Friend WithEvents colStatus As DataGridViewTextBoxColumn
End Class
