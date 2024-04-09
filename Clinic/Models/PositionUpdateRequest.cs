using System.Collections.Generic;

namespace Clinic.Models
{
    public class PositionUpdateRequest
    {
        public List<PosteUpdateRequest>? Postes { get; set; }
        public List<RepoUpdateRequest>? Repos { get; set; }
        public List<SupplementUpdateRequest>? Supplements { get; set; }
    }

    public class PosteUpdateRequest
    {
        public int Id { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }

    public class RepoUpdateRequest
    {
        public int Id { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }

    public class SupplementUpdateRequest
    {
        public int Id { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }
}
