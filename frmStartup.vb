Public Class frmStartup
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdCreate As System.Windows.Forms.Button
    Friend WithEvents lblDown As System.Windows.Forms.Label
    Friend WithEvents lblHoriz As System.Windows.Forms.Label
    Friend WithEvents lblSize As System.Windows.Forms.Label
    Friend WithEvents txtAcross As System.Windows.Forms.TextBox
    Friend WithEvents txtDown As System.Windows.Forms.TextBox
    Friend WithEvents txtSize As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdCreate = New System.Windows.Forms.Button()
        Me.lblDown = New System.Windows.Forms.Label()
        Me.lblHoriz = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.txtAcross = New System.Windows.Forms.TextBox()
        Me.txtDown = New System.Windows.Forms.TextBox()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(168, 136)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(104, 56)
        Me.cmdExit.TabIndex = 15
        Me.cmdExit.Text = "Exit"
        '
        'cmdCreate
        '
        Me.cmdCreate.Location = New System.Drawing.Point(24, 136)
        Me.cmdCreate.Name = "cmdCreate"
        Me.cmdCreate.Size = New System.Drawing.Size(104, 56)
        Me.cmdCreate.TabIndex = 14
        Me.cmdCreate.Text = "Create"
        '
        'lblDown
        '
        Me.lblDown.Location = New System.Drawing.Point(16, 88)
        Me.lblDown.Name = "lblDown"
        Me.lblDown.Size = New System.Drawing.Size(144, 23)
        Me.lblDown.TabIndex = 13
        Me.lblDown.Text = "Images Down:"
        '
        'lblHoriz
        '
        Me.lblHoriz.Location = New System.Drawing.Point(16, 48)
        Me.lblHoriz.Name = "lblHoriz"
        Me.lblHoriz.Size = New System.Drawing.Size(144, 24)
        Me.lblHoriz.TabIndex = 12
        Me.lblHoriz.Text = "Images Across:"
        '
        'lblSize
        '
        Me.lblSize.Location = New System.Drawing.Point(16, 8)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(144, 23)
        Me.lblSize.TabIndex = 11
        Me.lblSize.Text = "Image Size (px):"
        '
        'txtAcross
        '
        Me.txtAcross.Location = New System.Drawing.Point(184, 48)
        Me.txtAcross.MaxLength = 3
        Me.txtAcross.Name = "txtAcross"
        Me.txtAcross.Size = New System.Drawing.Size(88, 27)
        Me.txtAcross.TabIndex = 10
        Me.txtAcross.Text = "5"
        '
        'txtDown
        '
        Me.txtDown.Location = New System.Drawing.Point(184, 88)
        Me.txtDown.MaxLength = 3
        Me.txtDown.Name = "txtDown"
        Me.txtDown.Size = New System.Drawing.Size(88, 27)
        Me.txtDown.TabIndex = 9
        Me.txtDown.Text = "5"
        '
        'txtSize
        '
        Me.txtSize.Location = New System.Drawing.Point(184, 8)
        Me.txtSize.MaxLength = 3
        Me.txtSize.Name = "txtSize"
        Me.txtSize.Size = New System.Drawing.Size(88, 27)
        Me.txtSize.TabIndex = 8
        Me.txtSize.Text = "64"
        '
        'frmStartup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 20)
        Me.ClientSize = New System.Drawing.Size(292, 205)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdExit, Me.cmdCreate, Me.lblDown, Me.lblHoriz, Me.lblSize, Me.txtAcross, Me.txtDown, Me.txtSize})
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStartup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmStartup"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreate.Click
        ImageSize = Val(txtSize.Text)
        ImagesVertical = Val(txtDown.Text)
        ImagesHorizontal = Val(txtAcross.Text)

        If ImagesVertical < 1 Or ImagesHorizontal < 1 Then
            MsgBox("Although planned, single column and row features are not as yet implemented", MsgBoxStyle.Information, "System Notification")
            Exit Sub
        End If
        Initialize()

        UpdateStatus(0, 0)

        Me.Hide()

        Render()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Terminate()
        Me.Dispose()
        End
    End Sub

    Private Sub txtAcross_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcross.KeyUp
        If Val(txtAcross.Text) > 254 Then txtAcross.Text = 254
    End Sub

    Private Sub txtDown_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDown.KeyUp
        If Val(txtDown.Text) > 254 Then txtDown.Text = 254
    End Sub

    Private Sub txtSize_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSize.KeyUp
        If Val(txtSize.Text) > 254 Then txtSize.Text = 254
    End Sub
End Class
