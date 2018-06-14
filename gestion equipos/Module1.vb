Imports System
Imports System.IO
Imports System.Collections
Module Module1
    'conesion con  el servidor de base de datos 
    Public con As New OleDb.OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0; Data Source= D:\ismae\Documents\equipos1.1.mdb")

    'Conexión realizada con exito
    Public selecionada_equipos As String
    Public selecionada_tarea As String = ""
    Public selecionada_mantenimientto As String = ""
    Public marcada_tarea As Boolean
    Public marcada_mantenimiento As Boolean
    Public directorio As String
    Public filename As String
    Public directorio_base_datos As String
    Public directorio_dir As String = "D:\ismae\CICAP\"


    'establecer la conesion 
    Public Sub conectarse()
        Dim a As String
        directorio_base_datos = My.Settings.directorio

        If File.Exists(directorio_base_datos) Then

            a = Path.GetDirectoryName(directorio_base_datos)
            directorio_dir = a & "\Equipos\"

            MsgBox(directorio_dir)
            If directorio_base_datos <> "" Then

                Dim conm As New OleDb.OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0; Data Source=" + directorio_base_datos)
                con = conm
                Try
                    con.Open()
                    MsgBox("Conexión Exitosa con la base de datos", MsgBoxStyle.Information)

                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

            Else


            End If
        End If
    End Sub


    'funcion para gestionar los avisos
    Public Sub avisos()

        Dim id_tarea As String
        Dim id_equipo As String
        Dim cuenta As Integer
        Dim fecha As String = DateTime.Now.ToString("dd/MM/yyyy")
        Dim fecha_man As Date
        Dim dias As Integer = 0
        Dim fecha_actual As Date = DateTime.Now.ToString("dd/MM/yyyy")
        Dim fecha_mas_dias As Date
        Dim fecha_valida As String
        Dim descripcion As String
        Dim nume_tipo As Integer

        'conexion para las tareas
        Dim cmd1 As New OleDb.OleDbCommand
        Dim dr1 As OleDb.OleDbDataReader

        cmd1.Connection = con
        cmd1.CommandType = CommandType.Text
        cmd1.CommandText = "SELECT tareas.*, Equipos.ESTADO FROM Equipos INNER JOIN tareas ON Equipos.ID_EQUIPO = tareas.id_equipo WHERE (((Equipos.ESTADO)<>'BAJA')) "
        dr1 = cmd1.ExecuteReader()

        While dr1.Read()
            'datos extraidos  de tarreas 
            id_tarea = dr1(0).ToString
            id_equipo = dr1(1).ToString
            dias = dr1(3).ToString
            descripcion = dr1(2).ToString
            ''''''''''''''''''''''''''''''''''''''''''''''
            'conexion a mantenimiento 
            Dim cmd2 As New OleDb.OleDbCommand
            Dim dr2 As OleDb.OleDbDataReader

            cmd2.Connection = con
            cmd2.CommandType = CommandType.Text
            cmd2.CommandText = "SELECT * FROM mantenimiento  WHERE  tipo_tarea= " & id_tarea

            dr2 = cmd2.ExecuteReader()
            cuenta = 0 'contado para saber cuantos mantenimiento hay dde una tarea 
            While dr2.Read()

                fecha_valida = dr2(3).ToString 'fecha del mantenimiento 
                cuenta = cuenta + 1 ' cuanta mantenimientos
                If cuenta > 1 Then


                    Dim result1 As Integer = DateTime.Compare(Convert.ToDateTime(fecha), Convert.ToDateTime(fecha_valida))
                    If result1 < 0 Then ' si la fecha guardad es menos que la nueva 

                        fecha = fecha_valida ' guarda la nueva 

                    End If

                Else
                    fecha = fecha_valida ' guarda la fecha del unico mantenimiento 
                End If



            End While

            If cuenta = 0 Then ' si no hay manteniento llamamos a fecha de alta 
                Dim cmd3 As New OleDb.OleDbCommand
                Dim dr3 As OleDb.OleDbDataReader

                cmd3.Connection = con
                cmd3.CommandType = CommandType.Text
                cmd3.CommandText = "SELECT fecha_alta FROM Equipos  WHERE  Id_equipo= '" & id_equipo & "'"

                dr3 = cmd3.ExecuteReader()

                dr3.Read()
                fecha = dr3(0).ToString ' cogemos la fecha de alta 
                cuenta = 1 ' cuanta = 1

            End If
            ' si cuanta distinto de cera ya que el ok es cuando sea mayor de 0 
            If cuenta <> 0 Then

                fecha_man = Convert.ToDateTime(fecha) 'fecha de 

                fecha_mas_dias = fecha_man.AddDays(dias)

                Dim result As Integer = DateTime.Compare(fecha_mas_dias, fecha_actual)

                If result < 0 Then
                    'comprobamos que no se  ha insertado el aviso ya 
                    Dim cmd5 As New OleDb.OleDbCommand
                    Dim dr5 As OleDb.OleDbDataReader
                    cmd5.Connection = con
                    cmd5.CommandType = CommandType.Text
                    cmd5.CommandText = "SELECT * FROM avisos where id_tarea=" & id_tarea
                    dr5 = cmd5.ExecuteReader()
                    nume_tipo = 0

                    While dr5.Read()
                        nume_tipo = nume_tipo + 1

                    End While

                    If nume_tipo = 0 Then

                        Dim cmd4 As New OleDb.OleDbCommand
                        Dim dr4 As OleDb.OleDbDataReader

                        cmd4.Connection = con
                        cmd4.CommandType = CommandType.Text
                        cmd4.CommandText = "insert into avisos(id_equipo,id_tarea,fecha_caducidad,Descripcion) values ('" & id_equipo & "'," & id_tarea & ",'" & fecha_mas_dias & "','" & descripcion & "')"


                        dr4 = cmd4.ExecuteReader()
                        cuenta = 0
                        dr4.Read()

                        '''''''''''''''''''''''''
                    End If

                End If
            End If

        End While

        Dim cmd6 As New OleDb.OleDbCommand
        Dim dr6 As OleDb.OleDbDataReader
        cmd6.Connection = con
        cmd6.CommandType = CommandType.Text
        cmd6.CommandText = "SELECT * FROM avisos "
        dr6 = cmd6.ExecuteReader()


        While dr6.Read()

            Dim id_tarea_1 As String
            Dim id_equipo_1 As String
            Dim fecha_1 As String
            Dim dias_1 As String = ""
            Dim fecha_2 As String
            Dim id_Avisos As String


            id_Avisos = dr6(0).ToString
            id_tarea_1 = dr6(2).ToString
            id_equipo_1 = dr6(1).ToString
            fecha_1 = dr6(3).ToString


            Dim cmd8 As New OleDb.OleDbCommand
            Dim dr8 As OleDb.OleDbDataReader
            cmd8.Connection = con
            cmd8.CommandType = CommandType.Text
            cmd8.CommandText = "SELECT * FROM tareas where id_equipo= '" & id_equipo_1 & "'"
            dr8 = cmd8.ExecuteReader()
            While dr8.Read()
                dias_1 = dr8(3).ToString
            End While

            Dim cmd7 As New OleDb.OleDbCommand
            Dim dr7 As OleDb.OleDbDataReader
            cmd7.Connection = con
            cmd7.CommandType = CommandType.Text
            cmd7.CommandText = "SELECT * FROM mantenimiento where id_equipo= '" & id_equipo_1 & "'and tipo_tarea= " & id_tarea_1
            dr7 = cmd7.ExecuteReader()
            While dr7.Read()
                fecha_2 = dr7(3).ToString
                fecha_man = Convert.ToDateTime(fecha_2)

                fecha_mas_dias = fecha_man.AddDays(dias_1)

                Dim result As Integer = DateTime.Compare(fecha_mas_dias, Convert.ToDateTime(fecha_1))


                If result >= 0 Then
                    Dim cmd9 As New OleDb.OleDbCommand
                    Dim dr9 As OleDb.OleDbDataReader

                    cmd9.Connection = con
                    cmd9.CommandType = CommandType.Text

                    cmd9.CommandText = "delete from avisos where id_aviso=" & id_Avisos
                    dr9 = cmd9.ExecuteReader()
                    dr9.Read()

                Else

                End If
            End While
        End While
        Dim cmd10 As New OleDb.OleDbCommand
        Dim dr10 As OleDb.OleDbDataReader
        cmd10.Connection = con
        cmd10.CommandType = CommandType.Text
        cmd10.CommandText = "SELECT * FROM avisos "
        dr10 = cmd10.ExecuteReader()
        Dim cuenta1 As Integer = 0

        While dr10.Read()
            cuenta1 = cuenta1 + 1
        End While
        If cuenta1 <> 0 Then
            MsgBox("Hay" & cuenta1 & " equipos que necesintan mantenimiento")
        End If

    End Sub

    Public Function genera_codigo(ByVal reducion As String) As String
        Dim valida As Boolean = True
        Dim cuenta As Integer = 0
        Dim incremento As Integer = 1
        Dim codigo As String = ""



        While valida
            If reducion = "I" Then
                codigo = "CICAP-I-" & incremento
            ElseIf reducion = "A" Then
                codigo = "CILAB-A-" & incremento
            ElseIf reducion = "B" Then
                codigo = "CILAB-B-" & incremento
            ElseIf reducion = "E" Then
                codigo = "CILAB-E-" & incremento
            ElseIf reducion = "T" Then
                codigo = "CILAB-T-" & incremento
            Else
                codigo = "CILAB-P-" & incremento

            End If


            Dim cmd6 As New OleDb.OleDbCommand
            Dim dr6 As OleDb.OleDbDataReader
            cmd6.Connection = con
            cmd6.CommandType = CommandType.Text
            cmd6.CommandText = "SELECT * FROM Equipos where Id_equipo='" & codigo & "'"
            dr6 = cmd6.ExecuteReader()
            cuenta = 0
            While dr6.Read()
                cuenta = cuenta + 1
            End While

            If cuenta = 0 Then

                valida = False
            Else
                incremento = incremento + 1
            End If

        End While

        Return codigo
    End Function

End Module
