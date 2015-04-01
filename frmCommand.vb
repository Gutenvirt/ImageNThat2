Public Class frmCommand
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
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents FileSaver As System.Windows.Forms.SaveFileDialog
    Friend WithEvents optResize As System.Windows.Forms.CheckBox
    Friend WithEvents cmdNew As System.Windows.Forms.Button
    Friend WithEvents optLeftMouse As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.FileSaver = New System.Windows.Forms.SaveFileDialog()
        Me.optResize = New System.Windows.Forms.CheckBox()
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.optLeftMouse = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(8, 136)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(104, 56)
        Me.cmdExit.TabIndex = 0
        Me.cmdExit.Text = "Exit"
        '
        'cmdSave
        '
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSave.Location = New System.Drawing.Point(8, 72)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(104, 56)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "Save Master Image"
        '
        'cmdRefresh
        '
        Me.cmdRefresh.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRefresh.Location = New System.Drawing.Point(8, 8)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(104, 56)
        Me.cmdRefresh.TabIndex = 2
        Me.cmdRefresh.Text = "Refresh Screen"
        '
        'FileSaver
        '
        Me.FileSaver.Filter = "Bitmap Image (.bmp)|*.bmp"
        '
        'optResize
        '
        Me.optResize.Appearance = System.Windows.Forms.Appearance.Button
        Me.optResize.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optResize.Location = New System.Drawing.Point(144, 8)
        Me.optResize.Name = "optResize"
        Me.optResize.Size = New System.Drawing.Size(104, 56)
        Me.optResize.TabIndex = 3
        Me.optResize.Text = "Resize Small Images"
        Me.optResize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdNew
        '
        Me.cmdNew.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdNew.Location = New System.Drawing.Point(144, 136)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(104, 56)
        Me.cmdNew.TabIndex = 4
        Me.cmdNew.Text = "Create New"
        '
        'optLeftMouse
        '
        Me.optLeftMouse.Appearance = System.Windows.Forms.Appearance.Button
        Me.optLeftMouse.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optLeftMouse.Checked = True
        Me.optLeftMouse.CheckState = System.Windows.Forms.CheckState.Checked
        Me.optLeftMouse.Location = New System.Drawing.Point(144, 72)
        Me.optLeftMouse.Name = "optLeftMouse"
        Me.optLeftMouse.Size = New System.Drawing.Size(104, 56)
        Me.optLeftMouse.TabIndex = 5
        Me.optLeftMouse.Text = "Left Mouse To Paste"
        Me.optLeftMouse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmCommand
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 20)
        Me.ClientSize = New System.Drawing.Size(262, 197)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.optLeftMouse, Me.cmdNew, Me.optResize, Me.cmdRefresh, Me.cmdSave, Me.cmdExit})
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(240, 224)
        Me.Name = "frmCommand"
        Me.Text = "frmCommand"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Terminate()
        End
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        UpdateStatus(X, Y)
        Render()
    End Sub

    Private Sub frmCommand_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If WasActivated = False Then ActivateForms()
    End Sub

    Private Sub frmCommand_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        WasActivated = False
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        FileSaver.ShowDialog()
        If FileSaver.FileName.Length > 0 Then
            SaveImage(FileSaver.FileName)
        End If
    End Sub

    Private Sub optResize_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optResize.CheckedChanged
        If optResize.Checked = True Then ResizeImage = True
        If optResize.Checked = False Then ResizeImage = False
    End Sub

    Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        If MessageBox.Show("All acquired information is volitile, proceed?", "System Suggests Caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.OK Then
            Restart()
        End If
    End Sub

    Private Sub optLeftMouse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optLeftMouse.CheckedChanged
        If optLeftMouse.Checked = True Then LeftMouseToPaste = True
        If optLeftMouse.Checked = False Then LeftMouseToPaste = False
    End Sub

    Private Sub frmCommand_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Move
        InitializeForms()
    End Sub
End Class
