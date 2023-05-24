namespace ACLGithub.Entities;

public class Protection
{
    public bool enabled { get; set; }
    public RequiredStatusChecks required_status_checks { get; set; }
}