﻿namespace ACLGithub.Entities;

public class RequiredStatusChecks
{
    public string enforcement_level { get; set; }
    public List<object> contexts { get; set; }
    public List<object> checks { get; set; }
}