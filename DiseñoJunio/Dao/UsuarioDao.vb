
Imports System.Data.SqlClient


Public Class UsuarioDao

    Private strConn As String = My.Settings.StrConexion
    Public Function GuardarRegistro(ByVal usuario As UsuarioEntidad) As Boolean
        Dim resp As Boolean = False
        Try
            Dim tsql As String = "INSERT INTO Usuario(nombreUsuario, claveUsuario) values(@nombreU, @claveU)"
            Using conn As New SqlConnection(strConn)
                Using cmd As New SqlCommand(tsql, conn)

                    cmd.Parameters.AddWithValue("@nombreU", usuario.NombreUsuario)
                    cmd.Parameters.AddWithValue("@claveU", usuario.ClaveUsuario)

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

    Public Function EditarRegistro(ByVal usuario As UsuarioEntidad) As Boolean

        Dim resp As Boolean = False
        Try
            Dim tsql As String = "UPDATE Usuario SET nombreUsuario = @nombreU, claveUsuario = @claveU WHERE usuarioID = @usuarioID"
            Using conn As New SqlConnection(strConn)
                Using cmd As New SqlCommand(tsql, conn)
                    cmd.Parameters.AddWithValue("@nombreU", usuario.NombreUsuario)
                    cmd.Parameters.AddWithValue("@claveU", usuario.ClaveUsuario)
                    cmd.Parameters.AddWithValue("@usuarioID", usuario.UsuarioID)
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





    Public Function EliminarRegistro(ByVal usuarioID As Integer) As Boolean
        Dim resp As Boolean = False
        Try
            Dim tsql As String = "DELETE FROM Usuario  where usuarioID = @usuarioID"
            Dim conn As New SqlConnection(strConn)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = tsql

            cmd.Parameters.AddWithValue("@usuarioID", usuarioID)
            cmd.Connection = conn
            cmd.Connection.Open()

            If (cmd.ExecuteNonQuery <> 0) Then
                resp = True
            End If
            cmd.Connection.Close()

        Catch ex As Exception
            resp = False
        End Try
        Return resp

    End Function

    Public Function MostrarRegistros() As DataSet
        Dim ds As New DataSet
        Try
            Dim tsql As String = "select * from Usuario"

            Dim conn As New SqlConnection(strConn)
            Dim da As New SqlDataAdapter(tsql, conn)
            da.Fill(ds)
        Catch ex As Exception

        End Try
        Return ds
    End Function

    Public Function BuscarRegistro(ByVal nombreUsuario As String) As UsuarioEntidad
        Dim usuario As New UsuarioEntidad
        Try
            Dim tsql As String = "select * from Usuario where nombreUsuario = @nombreUsuario"
            Dim conn As New SqlConnection(strConn)
            Dim tbl As New DataTable
            Dim da As New SqlDataAdapter(tsql, conn)
            da.SelectCommand.Parameters.AddWithValue("@nombreUsuario", nombreUsuario)
            da.Fill(tbl)
            If tbl.Rows.Count > 0 Then
                usuario.UsuarioID = tbl.Rows(0).Item("usuarioID")
                usuario.NombreUsuario = tbl.Rows(0).Item("nombreUsuario")
                usuario.ClaveUsuario = tbl.Rows(0).Item("claveUsuario")
            End If
        Catch ex As Exception

        End Try
        Return usuario
    End Function



    'LISTAR DATOS USUARIO'
    Public Function ListarUsuario() As DataSet
        Dim ds As New DataSet
        Try
            Dim tsql As String = "SELECT * FROM Usuario"
            Dim conn As New SqlConnection(strConn)
            Dim da As New SqlDataAdapter(tsql, conn)
            da.Fill(ds)
        Catch ex As Exception
        End Try
        Return ds
    End Function

    Public Function VerificarCredenciales(ByVal usuario As String, ByVal contraseña As String) As Boolean
        Dim credencialesCorrectas As Boolean = False
        Try
            Dim tsql As String = "SELECT COUNT(*) FROM Usuario WHERE nombreUsuario = @usuario AND claveUsuario = @clave"
            Using conn As New SqlConnection(strConn)
                Using cmd As New SqlCommand(tsql, conn)
                    cmd.Parameters.AddWithValue("@usuario", usuario)
                    cmd.Parameters.AddWithValue("@clave", contraseña)
                    conn.Open()
                    Dim count As Integer = CInt(cmd.ExecuteScalar())
                    credencialesCorrectas = (count > 0)
                End Using
            End Using
        Catch ex As Exception
            credencialesCorrectas = False
        End Try
        Return credencialesCorrectas
    End Function










End Class
