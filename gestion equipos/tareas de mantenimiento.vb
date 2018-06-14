Public Class tareas_de_mantenimiento
    Private Sub tareas_de_mantenimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox4.Text = selecionada_equipos
        TextBox4.Enabled = False


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a As New Form2
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim id_equipo As String = selecionada_equipos
        Dim depscricion As String = TextBox1.Text
        Dim mantenimiento_calibracion As String = CheckedListBox1.GetItemChecked(1)
        Dim mantenimiento As String = CheckedListBox1.GetItemChecked(0)
        Dim periodo As String = TextBox2.Text
        Dim obserbacion As String = TextBox3.Text

        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader

        cmd.Connection = con
        cmd.CommandType = CommandType.Text


        cmd.CommandText = "insert into tareas(id_equipo,tipo,periodo,observaciones,M_preventivo,calibracion) values ('" & id_equipo & "','" & depscricion & "','" & periodo & "','" & obserbacion & "'," & mantenimiento & "," & mantenimiento_calibracion & " )"

        Try
            dr = cmd.ExecuteReader()
            dr.Read()
            MsgBox("Inserción de la tarea realizada con exito ")
            Dim a As New Form2
            a.Show()
            Me.Finalize()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



    End Sub


End Class