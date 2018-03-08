Imports System.IO
Public Class RealEstate

    Private m_YearPurchased As Integer
    Private m_PurchasePrice As Decimal
    Private m_Type As String
    Private m_Value2014 As Decimal

    Sub New()
        m_YearPurchased = 0
        m_PurchasePrice = 0
        m_Type = ""
        m_Value2014 = 0
    End Sub

    Sub New(yearPurchased As Integer, purchasePrice As Decimal, type As String, val2014 As Decimal)
        m_YearPurchased = yearPurchased
        m_PurchasePrice = purchasePrice
        m_Type = type
        m_Value2014 = val2014
    End Sub

    Public Property YearPurchased As Integer
        Set(ByVal value As Integer)
            m_YearPurchased = value
        End Set
        Get
            Return m_YearPurchased
        End Get
    End Property

    Public Property PurchasePrice As Decimal
        Set(ByVal value As Decimal)
            m_PurchasePrice = value
        End Set
        Get
            Return m_PurchasePrice
        End Get
    End Property

    Public Property Type As String
        Set(ByVal value As String)
            m_Type = value
        End Set
        Get
            Return m_Type
        End Get
    End Property

    Public Property Value2014 As Decimal
        Set(ByVal value As Decimal)
            m_Value2014 = value
        End Set
        Get
            Return m_Value2014
        End Get
    End Property

End Class
