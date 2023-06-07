
Imports System.Data.SqlClient


Public Class FacturaDao

    Private strConn As String = My.Settings.StrConexion



    Public Function GuardarRegistro(ByVal factura As FacturaEntidad) As Boolean

        Dim flag As Boolean = False
        Try
            Dim tsql As String = "INSERT INTO Factura(fechaFactura, totalFactura, consultaID) values(@fechaFactura, @totalFactura, @consultaID)"
            Dim conn As New SqlConnection(strConn)
            Dim cmd As New SqlCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = tsql
            cmd.Parameters.AddWithValue("@fechaFactura", factura.FechaFactura)
            cmd.Parameters.AddWithValue("@totalFactura", factura.TotalFactura)
            cmd.Parameters.AddWithValue("@consultaID", factura.ConsultaID.ConsultaID)

            cmd.Connection = conn
            cmd.Connection.Open()
            If (cmd.ExecuteNonQuery <> 0) Then
                flag = True
            End If
            cmd.Connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            flag = False
        End Try
        Return flag

    End Function

    Public Function MostrarRegistros() As DataSet
        Dim ds As New DataSet
        Try
            Dim tsql As String = "SELECT * from Factura "
            Dim conn As New SqlConnection(strConn)
            Dim da As New SqlDataAdapter(tsql, conn)
            da.Fill(ds)

        Catch ex As Exception
        End Try
        Return ds
    End Function

    Public Function BuscarRegistro(ByVal facturaID As Integer) As FacturaEntidad
        Dim factura As New FacturaEntidad
        Try
            Dim tsql As String = "select * from Factura where facturaID = @facturaID"
            Dim conn As New SqlConnection(strConn)
            Dim tbl As New DataTable
            Dim da As New SqlDataAdapter(tsql, conn)
            da.SelectCommand.Parameters.AddWithValue("@facturaID", facturaID)
            da.Fill(tbl)
            If tbl.Rows.Count > 0 Then
                factura.FacturaID = tbl.Rows(0).Item("facturaID")
                factura.FechaFactura = tbl.Rows(0).Item("fechaFactura")
                factura.TotalFactura = tbl.Rows(0).Item("totalFactura")
                factura.ConsultaID = tbl.Rows(0).Item("consultaID")
                factura.Deleted = tbl.Rows(0).Item("deleted")

            End If
        Catch ex As Exception

        End Try
        Return factura
    End Function

    ''EDITAR'

    Public Function ListarConsulta() As DataSet
        Dim ds As New DataSet
        Try
            Dim tsql As String = "SELECT CONVERT(varchar(10), Factura.fechaFactura, 103) as FechaFactura, Factura.totalFactura, Factura.consultaID, Paciente.deleted FROM Paciente"
            Dim conn As New SqlConnection(strConn)
            Dim da As New SqlDataAdapter(tsql, conn)
            da.Fill(ds)
        Catch ex As Exception
        End Try
        Return ds
    End Function


End Class
