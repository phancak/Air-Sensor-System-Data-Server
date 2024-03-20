using System;

/// <summary>
/// Struct containing message data to be transmitted to the database (Messages have contant length)
/// </summary>
public struct DatabaseMessageStruct
{
    /// <summary>
    /// Standard meesage format is DateTime, and two doubles for temperature and relative humidity
    /// </summary>
    public System.DateTime dateTime;
    public double temperature_value;
    public double RH_value;

    /// <summary>
    /// Initializes a new instance of MessageStruct with standard values
    /// </summary>
    /// <param name="msg_size"></param>
    public DatabaseMessageStruct()
    {
        this.dateTime = DateTime.Now;
        this.temperature_value = 0.0;
        this.RH_value = 0.0;
    }

    /// <summary>
    /// Initializes the struct with specified values
    /// </summary>
    /// <param name="dateTime">Intial date and time</param>
    /// <param name="temperature">Initial temperature</param>
    /// <param name="RH">Initial relative humidity</param>
    public DatabaseMessageStruct(DateTime dateTime, double temperature, double RH)
    {
        this.dateTime = dateTime;
        this.temperature_value = temperature;
        this.RH_value = RH;
    }
}