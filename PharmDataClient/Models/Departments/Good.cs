using Newtonsoft.Json;

namespace PharmDataClient.Models.Departments
{
    public class Good
    {
        [JsonProperty(Required = Required.Default, PropertyName = "refId")]
        public string? RefId { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "code")]
        public string? Code { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "name")]
        public string? Name { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "producer")]
        public string? Producer { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "country")]
        public string? Country { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "barcodes")]
        public List<string>? Barcodes { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "goodsGroupCodes")]
        public List<string>? GoodsGroupCodes { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "mnnEn")]
        public string? MnnEn { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "mnnRu")]
        public string? MnnRu { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "rv")]
        public string? Rv { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "created")]
        public string? Created { get; set; }
    }
}
