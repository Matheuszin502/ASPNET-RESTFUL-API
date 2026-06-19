using RestWithASPNET.Hypermedia.Abstract;

namespace RestWithASPNET.Hypermedia.Filters
{
    public class HypermediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = [];
    }
}
