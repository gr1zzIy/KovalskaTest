namespace KovalskaTest.Models;

public class JsonRpcRequest
{
    public string Jsonrpc { get; init; } = "2.0";
    public string Method { get; init; } = "TestMonitoringPlan";
    public string Id { get; init; } = Guid.NewGuid().ToString();
    public object Params { get; init; }
}