Public Class FacturaEntidad

    Private _facturaID As Integer
    Private _fechaFactura As DateTime
    Private _totalFactura As Decimal
    Private _consultaID As ConsultaEntidad
    Private _deleted As Boolean


    Public Property FacturaID As Integer
        Get
            Return _facturaID

        End Get
        Set(value As Integer)
            _facturaID = value

        End Set
    End Property

    Public Property FechaFactura As DateTime
        Get
            Return _fechaFactura

        End Get
        Set(value As DateTime)
            _fechaFactura = value

        End Set
    End Property

    Public Property TotalFactura As Decimal
        Get
            Return _totalFactura

        End Get
        Set(value As Decimal)
            _totalFactura = value

        End Set
    End Property

    Public Property ConsultaID As ConsultaEntidad
        Get
            Return _consultaID

        End Get
        Set(value As ConsultaEntidad)
            _consultaID = value

        End Set
    End Property

    Public Property Deleted As Boolean
        Get
            Return _deleted

        End Get
        Set(value As Boolean)
            _deleted = value

        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(facturaID As Integer, fechaFactura As DateTime, totalFactura As Decimal, consulta As ConsultaEntidad, deleted As Boolean)
        Me.FacturaID = facturaID
        Me.FechaFactura = fechaFactura
        Me.TotalFactura = totalFactura
        Me.ConsultaID = consulta
        Me.Deleted = deleted
    End Sub

End Class
