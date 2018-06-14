Public Class Form6
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tipo As String = ComboBox1.Text
        Dim Codigo_mantenimiento As String = TextBox26.Text
        Dim grupo As String = ComboBox3.Text
        Dim fecha_de_mantenimiento As String = TextBox24.Text
        Dim Estado As String = ComboBox2.Text
        Dim obserbaciones As String = TextBox17.Text
        Dim t_M_Preventivo As String = CheckedListBox2.GetItemChecked(0)
        Dim t_M_correctivo As String = CheckedListBox2.GetItemChecked(1)
        Dim t_calibracion As String = CheckedListBox2.GetItemChecked(2)

        Dim fecha_baja As String = TextBox14.Text
        Dim tarea As String = ComboBox1.Text


        Dim cmd1 As New OleDb.OleDbCommand
        Dim dr1 As OleDb.OleDbDataReader

        cmd1.Connection = con
        cmd1.CommandType = CommandType.Text
        cmd1.CommandText = "SELECT tareas.tipo, tareas.Id_tipo, tareas.id_equipo, Equipos.ESTADO From Equipos INNER Join tareas On Equipos.ID_EQUIPO = tareas.id_equipo Where tareas.tipo = '" & tipo & "' And Equipos.ESTADO <> 'BAJA'  And Equipos.TIPO=  '" & grupo & "'"
        dr1 = cmd1.ExecuteReader()


        While dr1.Read()

            Dim id_equipo As String = dr1(2).ToString
            Dim id_tipo As String = dr1(1).ToString

            Dim resultado As String = ""
            resultado = MsgBox(id_equipo, MsgBoxStyle.YesNo)

            If resultado = vbYes Then
                Dim cmd As New OleDb.OleDbCommand
                Dim dr As OleDb.OleDbDataReader

                cmd.Connection = con
                cmd.CommandType = CommandType.Text

                cmd.CommandText = "insert into mantenimiento(id_equipo,operacion,fecha_mantenimiento,M_Preventivo,M_correctivo,calibracion,estado,observaciones,tipo_tarea) values ('" & id_equipo & "','" & tipo & "','" & fecha_de_mantenimiento & "'," & t_M_Preventivo & "," & t_M_correctivo & "," & t_calibracion & ",'" & Estado & "',' " & obserbaciones & " '," & id_tipo & ")"


                Try
                    dr = cmd.ExecuteReader()
                    dr.Read()

                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                Dim cmd2 As New OleDb.OleDbCommand
                Dim dr2 As OleDb.OleDbDataReader
                cmd2.Connection = con
                cmd2.CommandType = CommandType.Text




                If Estado = "BAJA" Then
                    cmd2.CommandText = "update Equipos set estado='" & Estado & "', fecha_baja='" & fecha_baja & "' where id_Equipo='" & id_equipo & "'"
                Else
                    cmd2.CommandText = "update Equipos set estado='" & Estado & "' where id_Equipo='" & id_equipo & "'"
                End If

                Try
                    dr2 = cmd2.ExecuteReader()
                    dr2.Read()



                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try



            End If
        End While
       

        MsgBox("Inserción de la tareas realizadas con exito ")
        Dim a As New Form1
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TextBox24.Text = DateTime.Now.ToString("dd/MM/yyyy")
        TextBox14.Enabled = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "BAJA" Then
            TextBox14.Text = TextBox24.Text
            TextBox14.Enabled = True
        Else
            TextBox14.Text = ""
            TextBox14.Enabled = False
        End If

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        ComboBox1.Items.Clear()

        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader
        Dim cuenta As Integer
        Dim grupo As String = ComboBox3.Text
        cmd.Connection = con
        cmd.CommandType = CommandType.Text


        cmd.CommandText = " SELECT tareas.tipo, Equipos.ESTADO From Equipos INNER Join tareas On Equipos.ID_EQUIPO = tareas.id_equipo Where Equipos.ESTADO <> 'BAJA' And Equipos.TIPO=  '" & grupo & "'"
        dr = cmd.ExecuteReader()
        While dr.Read()

            Dim cmd1 As New OleDb.OleDbCommand
            Dim dr1 As OleDb.OleDbDataReader

            cmd1.Connection = con
            cmd1.CommandType = CommandType.Text
            cmd1.CommandText = " SELECT tareas.tipo, Equipos.ESTADO From Equipos INNER Join tareas On Equipos.ID_EQUIPO = tareas.id_equipo Where Equipos.ESTADO <> 'BAJA' AND  tareas.tipo ='" & dr(0).ToString & "' And Equipos.TIPO=  '" & grupo & "'"
            dr1 = cmd1.ExecuteReader()
            cuenta = 0
            While dr1.Read()
                cuenta = cuenta + 1
            End While
            If cuenta > 1 Then
                If ComboBox1.FindString(dr(0).ToString()) = -1 Then
                    ComboBox1.Items.Add(dr(0).ToString())
                End If
            End If
        End While
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub
End Class