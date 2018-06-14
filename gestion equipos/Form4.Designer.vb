<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form4
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBox17 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CheckedListBox2 = New System.Windows.Forms.CheckedListBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TextBox24 = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TextBox25 = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TextBox26 = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1094, 246)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 68
        Me.Button2.Text = "Volver"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1013, 191)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 67
        Me.Button1.Text = "MODIFICAR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1094, 191)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 85
        Me.Button3.Text = "ELIMINAR"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TextBox15
        '
        Me.TextBox15.Location = New System.Drawing.Point(954, 115)
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(215, 20)
        Me.TextBox15.TabIndex = 86
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(1098, 141)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(71, 23)
        Me.Button9.TabIndex = 105
        Me.Button9.Text = "Eliminar"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(951, 102)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 13)
        Me.Label19.TabIndex = 103
        Me.Label19.Text = "Certificacion"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(954, 141)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(71, 23)
        Me.Button7.TabIndex = 104
        Me.Button7.Text = "Añadir"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(184, 8)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(131, 13)
        Me.Label16.TabIndex = 102
        Me.Label16.Text = "TARREA PROGRAMADA"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"BAJA", "FUERA DE SERVICIO", "LIMITACION DE USO", "OK", "REPARACIÓN"})
        Me.ComboBox2.Location = New System.Drawing.Point(22, 77)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(150, 21)
        Me.ComboBox2.TabIndex = 98
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(184, 62)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(98, 13)
        Me.Label17.TabIndex = 97
        Me.Label17.Text = "OBSERVACIONES"
        '
        'TextBox17
        '
        Me.TextBox17.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox17.Location = New System.Drawing.Point(187, 76)
        Me.TextBox17.Multiline = True
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New System.Drawing.Size(748, 143)
        Me.TextBox17.TabIndex = 96
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(969, 8)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(162, 13)
        Me.Label23.TabIndex = 95
        Me.Label23.Text = "TAREAS DE MANTENIMIENTO"
        '
        'CheckedListBox2
        '
        Me.CheckedListBox2.FormattingEnabled = True
        Me.CheckedListBox2.Items.AddRange(New Object() {"M.PREVENTIVO ", "M.CORRECTIVO", "CALIBRACIÓN"})
        Me.CheckedListBox2.Location = New System.Drawing.Point(972, 24)
        Me.CheckedListBox2.Name = "CheckedListBox2"
        Me.CheckedListBox2.Size = New System.Drawing.Size(156, 49)
        Me.CheckedListBox2.TabIndex = 94
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(19, 60)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(51, 13)
        Me.Label24.TabIndex = 93
        Me.Label24.Text = "ESTADO"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(790, 8)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(154, 13)
        Me.Label26.TabIndex = 92
        Me.Label26.Text = "FECHA DE MANTENIMIENTO"
        '
        'TextBox24
        '
        Me.TextBox24.Location = New System.Drawing.Point(796, 23)
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New System.Drawing.Size(150, 20)
        Me.TextBox24.TabIndex = 91
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(362, 8)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(70, 13)
        Me.Label27.TabIndex = 90
        Me.Label27.Text = "OPERACIÓN"
        '
        'TextBox25
        '
        Me.TextBox25.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox25.Location = New System.Drawing.Point(365, 24)
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Size = New System.Drawing.Size(394, 20)
        Me.TextBox25.TabIndex = 89
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(19, 8)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(49, 13)
        Me.Label28.TabIndex = 88
        Me.Label28.Text = "CODIGO"
        '
        'TextBox26
        '
        Me.TextBox26.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox26.Location = New System.Drawing.Point(22, 24)
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New System.Drawing.Size(150, 20)
        Me.TextBox26.TabIndex = 87
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(1039, 141)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(53, 23)
        Me.Button4.TabIndex = 107
        Me.Button4.Text = "Abrir"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(187, 24)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(156, 21)
        Me.ComboBox1.TabIndex = 108
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1185, 291)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.TextBox15)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TextBox17)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.CheckedListBox2)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.TextBox24)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.TextBox25)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.TextBox26)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form4"
        Me.Text = "Detalles del Mantenimiento"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents TextBox15 As TextBox
    Friend WithEvents Button9 As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents TextBox17 As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents CheckedListBox2 As CheckedListBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents TextBox24 As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents TextBox25 As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Protected WithEvents TextBox26 As TextBox
End Class
