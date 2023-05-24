namespace ACLGithub.Entities;

public class Webhook
{ 
        public string Name { get; set; }
        public Commit Commit { get; set; }
        public bool Protected { get; set; }
        public Protection Protection { get; set; } 
        public string Protection_url { get; set; }
}