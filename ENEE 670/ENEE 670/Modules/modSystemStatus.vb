Module modSystemStatus
    Public pnlSystemMessages As ctlStatusMessages = New ctlStatusMessages()
    Public statusMessage() As clsStatusMessage
    Public logFile As System.IO.StreamWriter

    Private Enum enumStatusMessage
        OUT_OF_RANGE
        LOW_PRESSURE
    End Enum

    Public Sub Initialize()
        InitializeStatusMessages()
        logFile = My.Computer.FileSystem.OpenTextFileWriter(Application.StartupPath + "\NGSWAT_Log_" + Math.Round((DateTime.Now - New DateTime(1970, 1, 1)).TotalSeconds).ToString() + ".csv", True)
        WriteLogFileHeaders()
    End Sub

    Private Sub InitializeStatusMessages()
        ReDim statusMessage([Enum].GetValues(GetType(enumStatusMessage)).Length - 1)
        statusMessage(enumStatusMessage.OUT_OF_RANGE) = New clsStatusMessage(enumStatusMessage.OUT_OF_RANGE, Now(), "A", "Out of range", "Out of range - Details")
        statusMessage(enumStatusMessage.LOW_PRESSURE) = New clsStatusMessage(enumStatusMessage.OUT_OF_RANGE, Now(), "A", "Low Pressure", "Low Pressure - Details")
    End Sub

    Private Sub WriteLogFileHeaders()
        ' Timestamp and ID for all messages
        logFile.Write("Time,")
        logFile.Write("Message ID,")
        ' START Command fields
        logFile.Write("Initial Ammonia Concentration,")
        logFile.Write("Initial Hydrogen Sulfide Concentration,")
        logFile.Write("Maximum Pressure,")
        logFile.Write("Volumetric Flow Rate,")
        logFile.Write("Cost Per Gram (Copper Sulfate),")
        logFile.Write("Cost Per Gram (Ammonia),")
        logFile.Write("Cost Per Gram (Sulfuric Acid),")
        logFile.Write("Cost Per Kilowatt Hour,")
        logFile.Write("Number of Chemical Analyzers,")
        ' SYSTEM STATUS fields
        logFile.Write("Volumetric Flow Rate,")
        logFile.Write("Hydrogen Sulfide Concentration,")
        logFile.Write("Ammonia Concentration,")
        logFile.Write("Water Concentration,")
        logFile.Write("Max Applied Pressure,")
        logFile.Write("Concentration of Hydrogen Sulfide (leaving CSTR),")
        logFile.Write("Concentration of Ammonia (leaving CSTR),")
        logFile.Write("Concentration of Hydrogen Sulfide (leaving SSU),")
        logFile.Write("Concentration of Ammonia (leaving SUU),")
        logFile.Write("Final Concentration of Hydrogen Sulfide,")
        logFile.Write("Final Concentration of Ammonia,")
        logFile.Write("Final Concentration of Water,")
        logFile.Write("Clean Water Production Percentage,")
        logFile.Write("Current Cost Of Power Per Second,")
        logFile.Write("Current Cost Of Chemicals Per Second,")
        logFile.Write("Current Segment Cost Per Liter,")
        logFile.Write("Grams CuS,")
        logFile.Write("Grams NH3,")
        logFile.Write("Grams H2SO4,")
        logFile.Write("NGSWAT-100,")
        logFile.Write("NGSWAT-200,")
        logFile.Write("NGSWAT-300,")
        logFile.Write("NGSWAT-400,")
        ' SIMULATION TICK fields
        logFile.Write("Simulation Ticks,")
        logFile.Write("Segment Ticks,")
        logFile.Write("Segment Liters Treated,")
        logFile.Write("Segment Cost,")
        logFile.Write("Max Hydrogen Sulfide Concentration,")
        logFile.Write("Min Hydrogen Sulfide Concentration,")
        logFile.Write("Max Ammonia Concentration,")
        logFile.Write("Min Ammonia Concentration,")
        logFile.Write("Max Clean Water Percentage,")
        logFile.Write("Min Clean Water Percentage,")
        logFile.Write("Max Cost Per Liter,")
        logFile.Write("Min Cost Per Liter,")
        logFile.Write("Total Cost,")
        logFile.Write("Total Liters Treated,")
        logFile.Write("Average Cost Per Liter,")
        logFile.Write("Average Hydrogen Sulfide Concentration,")
        logFile.Write("Average Ammonia Concentration,")
        logFile.Write("Average Clean Water Percentage" + vbCrLf)
    End Sub

    Public Sub writeToLog(values As String())
        For Each str As String In values
            logFile.Write(str + ",")
        Next
        logFile.Write(vbCrLf)
    End Sub
End Module
