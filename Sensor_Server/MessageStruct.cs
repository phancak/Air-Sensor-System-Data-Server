using System;

/// <summary>
/// Struct containing message data (Messages have contant length)
/// </summary>
public struct MessageStruct
{
    /// <summary>
    /// Standard meesage format is array of integers (even though it comes from the device in 8bit array)
    /// </summary>
    public int[] message;

    /// <summary>
    /// Initializes a new instance of MessageStruct with specified message size
    /// </summary>
    /// <param name="msg_size"></param>
    public MessageStruct(int msg_size)
    {
        message = new int[msg_size]; //msg_size is globla variable
    }
}