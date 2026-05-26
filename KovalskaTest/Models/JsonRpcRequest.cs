namespace KovalskaTest.Models;

public class JsonRpcRequest
{
    public string Jsonrpc { get; set; } = "2.0";
    public string Method { get; set; } = "TestMonitoringPlan";
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public object Params { get; set; }
}