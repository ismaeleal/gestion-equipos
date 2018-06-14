Public Class Form5
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tipo As String = ComboBox2.Text
        Dim depscricion As String = TextBox1.Text
        Dim mantenimiento_calibracion As String = CheckedListBox1.GetItemChecked(1)
        Dim mantenimiento As String = CheckedListBox1.GetItemChecked(0)
        Dim periodo As String = TextBox2.Text
        Dim obserbacion As String = TextBox3.Text


        Dim cmd1 As New OleDb.OleDbCommand
        Dim dr1 As OleDb.OleDbDataReader

        cmd1.Connection = con
        cmd1.CommandType = CommandType.Text
        cmd1.CommandText = "SELECT * FROM Equipos where TIPO='" & tipo & "'"
        dr1 = cmd1.ExecuteReader()

        While dr1.Read()
            Dim id_equipo As String = dr1(0).ToString
            Dim resultado As String = ""
            resultado = MsgBox(id_equipo, MsgBoxStyle.YesNo)

            If resultado = vbYes Then
                Dim cmd As New OleDb.OleDbCommand
                Dim dr As OleDb.OleDbDataReader

                cmd.Connection = con
                cmd.CommandType = CommandType.Text


                cmd.CommandText = "insert into tareas(id_equipo,tipo,periodo,observaciones,M_preventivo,calibracion) values ('" & id_equipo & "','" & depscricion & "','" & periodo & "','" & obserbacion & "'," & mantenimiento & "," & mantenimiento_calibracion & " )"

                Try
                    dr = cmd.ExecuteReader()
                    dr.Read()


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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a As New Form1
        a.Show()
        Me.Finalize()
    End Sub
End Class