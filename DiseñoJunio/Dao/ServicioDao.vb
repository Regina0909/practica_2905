
Imports System.Data.SqlClient
Public Class ServicioDao

    Private strConn As String = My.Settings.StrConexion
    Public Function GuardarRegistro(ByVal servicio As ServicioEntidad) As Boolean
        Dim resp As Boolean = False
        Try
            Dim tsql As String = "INSERT INTO Servicio(nombreServicio, costoServicio, deleted) values(@nombreS, @costoS, @deleted)"
            Using conn As New SqlConnection(strConn)
                Using cmd As New SqlCommand(tsql, conn)

                    cmd.Parameters.AddWithValue("@nombreS", servicio.NombreServicio)
                    cmd.Parameters.AddWithValue("@costoS", servicio.CostoServicio)
                    cmd.Parameters.AddWithValue("@deleted", servicio.Deleted)

                    conn.Open()
                    If cmd.ExecuteNonQuery() > 0 Then
                        resp = True
                    End If
                End Using
            End Using
        Catch ex As Exception
            resp = False
        End Try
        Return resp
    End Function

    Public Function EditarRegistro(ByVal servicio As ServicioEntidad) As Boolean
        Dim resp As Boolean = False
        Try
            Dim tsql As String = "UPDATE Servicio SET nombreServicio = @nombreS, costoServicio = @costoS, deleted = @deleted WHERE servicioID = @servicioID"
            Using conn As New SqlConnection(strConn)
                Using cmd As New SqlCommand(tsql, conn)
                    cmd.Parameters.AddWithValue("@nombreS", servicio.NombreServicio)
                    cmd.Parameters.AddWithValue("@costoS", servicio.CostoServicio)
                    cmd.Parameters.AddWithValue("@deleted", servicio.Deleted)
                    cmd.Parameters.AddWithValue("@servicioID", servicio.ServicioID)
                    conn.Open()
                    If cmd.ExecuteNonQuery() > 0 Then
                        resp = True
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error al editar el registro: " & ex.Message, MsgBoxStyle.Critical, "Clinica")
            resp = False
        End Try
        Return resp

    End Function

    Public Function MostrarRegistros() As DataSet
        Dim ds As New DataSet
        Try
            Dim tsql As String = "select * from Servicio WHERE deleted = 0"
            Dim conn As New SqlConnection(strConn)
            Dim da As New SqlDataAdapter(tsql, conn)
            da.Fill(ds)
        Catch ex As Exception

        End Try
        Return ds
    End Function

    Public Function BuscarRegistro(ByVal servicioID As Integer) As ServicioEntidad
        Dim servicio As New ServicioEntidad
        Try
            Dim tsql As String = "select * from Servicio where servicioID = @servcicioID"
            Dim conn As New SqlConnection(strConn)
            Dim tbl As New DataTable
            Dim da As New SqlDataAdapter(tsql, conn)
            da.SelectCommand.Parameters.AddWithValue("@servicioID", servicioID)
            da.Fill(tbl)
            If tbl.Rows.Count > 0 Then
                servicio.ServicioID = tbl.Rows(0).Item("servcioID")
                servicio.NombreServicio = tbl.Rows(0).Item("nombreServicio")
                servicio.CostoServicio = tbl.Rows(0).Item("claveUsuario")
                servicio.Deleted = tbl.Rows(0).Item("deleted")


            End If
        Catch ex As Exception

        End Try
        Return servicio
    End Function

    Public Function ListarServicio() As DataSet
        Dim ds As New DataSet
        Try
            Dim tsql As String = "SELECT * FROM Servicio"
            Dim conn As New SqlConnection(strConn)
            Dim da As New SqlDataAdapter(tsql, conn)
            da.Fill(ds)
        Catch ex As Exception
        End Try
        Return ds
    End Function

    Public Function EliminarRegistro(ByVal servicioID As Integer) As Boolean
        Dim resp As Boolean = False
        Try
            Dim tsql As String = "UPDATE Servicio SET deleted = 1 WHERE servicioID = @servicioID"
            Using conn As New SqlConnection(strConn)
                Using cmd As New SqlCommand(tsql, conn)
                    cmd.Parameters.AddWithValue("@servicioID", servicioID)
                    conn.Open()
                    If cmd.ExecuteNonQuery() > 0 Then
                        resp = True
                    End If
                End Using
            End Using
        Catch ex As Exception
            resp = False
        End Try
        Return resp
    End Function
End Class
