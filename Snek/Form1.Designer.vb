<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Snek
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Snek))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.box_score = New System.Windows.Forms.RichTextBox()
        Me.delay_box = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.img1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.box_highScore = New System.Windows.Forms.RichTextBox()
        CType(Me.img1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(815, 399)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(150, 40)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "New Game"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn2
        '
        Me.btn2.Location = New System.Drawing.Point(815, 445)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(150, 40)
        Me.btn2.TabIndex = 1
        Me.btn2.Text = "Quit Snek"
        Me.btn2.UseVisualStyleBackColor = True
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.Font = New System.Drawing.Font("News706 BT", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.Location = New System.Drawing.Point(806, 9)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(159, 25)
        Me.lbl1.TabIndex = 3
        Me.lbl1.Text = "HIGH SCORE"
        '
        'box_score
        '
        Me.box_score.Location = New System.Drawing.Point(811, 135)
        Me.box_score.Name = "box_score"
        Me.box_score.ReadOnly = True
        Me.box_score.Size = New System.Drawing.Size(150, 25)
        Me.box_score.TabIndex = 4
        Me.box_score.Text = ""
        '
        'delay_box
        '
        Me.delay_box.Location = New System.Drawing.Point(918, 184)
        Me.delay_box.Name = "delay_box"
        Me.delay_box.Size = New System.Drawing.Size(47, 20)
        Me.delay_box.TabIndex = 5
        Me.delay_box.Text = "200"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(777, 182)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(118, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Enter Delay:"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'img1
        '
        Me.img1.Image = Global.Snek.My.Resources.Resources.rsz_snek_2
        Me.img1.Location = New System.Drawing.Point(777, 218)
        Me.img1.Name = "img1"
        Me.img1.Size = New System.Drawing.Size(241, 154)
        Me.img1.TabIndex = 2
        Me.img1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("News706 BT", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(853, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 25)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Score"
        '
        'box_highScore
        '
        Me.box_highScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.box_highScore.Location = New System.Drawing.Point(811, 47)
        Me.box_highScore.Name = "box_highScore"
        Me.box_highScore.ReadOnly = True
        Me.box_highScore.Size = New System.Drawing.Size(150, 40)
        Me.box_highScore.TabIndex = 8
        Me.box_highScore.Text = ""
        '
        'Snek
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 497)
        Me.Controls.Add(Me.box_highScore)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.delay_box)
        Me.Controls.Add(Me.box_score)
        Me.Controls.Add(Me.lbl1)
        Me.Controls.Add(Me.img1)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Snek"
        Me.Text = "Snek the game"
        CType(Me.img1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents btn2 As Button
    Friend WithEvents img1 As PictureBox
    Friend WithEvents lbl1 As Label
    Friend WithEvents box_score As RichTextBox
    Friend WithEvents delay_box As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents box_highScore As RichTextBox
End Class
