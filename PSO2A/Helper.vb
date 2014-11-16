Public Class Helper
    Public Shared ReadOnly JPTimeInfo As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time")

    Public Shared Function JapanTimeToLocal(hour As Integer, minutes As Integer, localTime As TimeZoneInfo) As DateTime
        Dim currentDate = DateTime.Now
        Dim selectedTimeZone = TimeZoneInfo.Local
        Dim EQDate = New DateTime(currentDate.Year, currentDate.Day, currentDate.Hour, hour, minutes, 0)
        Dim localEQDateIn = TimeZoneInfo.ConvertTime(EQDate, JPTimeInfo, selectedTimeZone)

        If (selectedTimeZone.SupportsDaylightSavingTime AndAlso selectedTimeZone.IsDaylightSavingTime(localEQDateIn)) Then
            localEQDateIn = localEQDateIn.AddHours(-1)
        End If

        Return localEQDateIn
    End Function
End Class
