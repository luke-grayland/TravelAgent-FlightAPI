using System.Text.Json.Serialization;

public class FlightSearchResponse
{
    [JsonPropertyName("warnings")]
    public List<Issue> Warnings { get; set; }

    [JsonPropertyName("meta")]
    public Meta Meta { get; set; }

    [JsonPropertyName("data")]
    public List<AmadeusFlightOffer> FlightOffers { get; set; }

    [JsonPropertyName("dictionaries")]
    public Dictionaries Dictionaries { get; set; }
}

public class Issue
{
    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("code")]
    public long Code { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("detail")]
    public string Detail { get; set; }

    [JsonPropertyName("explanation")]
    public string Explanation { get; set; }

    [JsonPropertyName("source")]
    public IssueSource Source { get; set; }
}

public class IssueSource
{
    [JsonPropertyName("pointer")]
    public string Pointer { get; set; }

    [JsonPropertyName("parameter")]
    public string Parameter { get; set; }

    [JsonPropertyName("example")]
    public string Example { get; set; }
}

public class Meta
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("oneWayCombinations")]
    public List<OneWayCombination> OneWayCombinations { get; set; }
}

public class OneWayCombination
{
    [JsonPropertyName("originDestinationId")]
    public string OriginDestinationId { get; set; }

    [JsonPropertyName("flightOfferIds")]
    public List<string> FlightOfferIds { get; set; }
}

public class AmadeusFlightOffer
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("source")]
    public string Source { get; set; }

    [JsonPropertyName("instantTicketingRequired")]
    public bool InstantTicketingRequired { get; set; }

    [JsonPropertyName("disablePricing")]
    public bool DisablePricing { get; set; }

    [JsonPropertyName("nonHomogeneous")]
    public bool NonHomogeneous { get; set; }

    [JsonPropertyName("oneWay")]
    public bool OneWay { get; set; }

    [JsonPropertyName("paymentCardRequired")]
    public bool PaymentCardRequired { get; set; }

    [JsonPropertyName("lastTicketingDate")]
    public string? LastTicketingDate { get; set; }

    [JsonPropertyName("lastTicketingDateTime")]
    public DateTime? LastTicketingDateTime { get; set; }

    [JsonPropertyName("numberOfBookableSeats")]
    public int NumberOfBookableSeats { get; set; }

    [JsonPropertyName("itineraries")]
    public List<Itinerary> Itineraries { get; set; }

    [JsonPropertyName("price")]
    public Price Price { get; set; }

    [JsonPropertyName("pricingOptions")]
    public PricingOptions PricingOptions { get; set; }

    [JsonPropertyName("validatingAirlineCodes")]
    public List<string> ValidatingAirlineCodes { get; set; }

    [JsonPropertyName("travelerPricings")]
    public List<TravelerPricing> TravelerPricings { get; set; }
}

public class Itinerary
{
    [JsonPropertyName("duration")]
    public string Duration { get; set; }

    [JsonPropertyName("segments")]
    public List<Segment> Segments { get; set; } = [];
}

public class Segment
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("numberOfStops")]
    public int NumberOfStops { get; set; }

    [JsonPropertyName("blacklistedInEU")]
    public bool BlacklistedInEU { get; set; }

    [JsonPropertyName("co2Emissions")]
    public List<Co2Emission> Co2Emissions { get; set; }

    [JsonPropertyName("departure")]
    public FlightEndPoint Departure { get; set; }

    [JsonPropertyName("arrival")]
    public FlightEndPoint Arrival { get; set; }

    [JsonPropertyName("carrierCode")]
    public string CarrierCode { get; set; }

    [JsonPropertyName("number")]
    public string Number { get; set; }

    [JsonPropertyName("aircraft")]
    public AircraftEquipment Aircraft { get; set; }

    [JsonPropertyName("operating")]
    public OperatingFlight Operating { get; set; }

    //Duration in ISO8601 PnYnMnDTnHnMnS format, example: PT2H10M
    [JsonPropertyName("duration")]
    public string Duration { get; set; }

    [JsonPropertyName("stops")]
    public List<FlightStop> Stops { get; set; }
}

public class Co2Emission
{
    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    [JsonPropertyName("weightUnit")]
    public string WeightUnit { get; set; }

    [JsonPropertyName("cabin")]
    public string Cabin { get; set; }
}

public class FlightEndPoint
{
    [JsonPropertyName("iataCode")]
    public string IataCode { get; set; }

    [JsonPropertyName("terminal")]
    public string Terminal { get; set; }

    [JsonPropertyName("at")]
    public DateTime At { get; set; }
}

public class AircraftEquipment
{
    [JsonPropertyName("code")]
    public string Code { get; set; }
}

public class OperatingFlight
{
    [JsonPropertyName("carrierCode")]
    public string CarrierCode { get; set; }
}

public class FlightStop
{
    [JsonPropertyName("iataCode")]
    public string IataCode { get; set; }

    [JsonPropertyName("duration")]
    public string Duration { get; set; }

    [JsonPropertyName("arrivalAt")]
    public DateTime ArrivalAt { get; set; }

    [JsonPropertyName("departureAt")]
    public DateTime DepartureAt { get; set; }
}

public class Price
{
    [JsonPropertyName("margin")]
    public string Margin { get; set; }

    [JsonPropertyName("grandTotal")]
    public string GrandTotal { get; set; }

    [JsonPropertyName("billingCurrency")]
    public string BillingCurrency { get; set; }

    [JsonPropertyName("additionalServices")]
    public List<AdditionalService> AdditionalServices { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("total")]
    public string Total { get; set; }

    [JsonPropertyName("base")]
    public string Base { get; set; }

    [JsonPropertyName("fees")]
    public List<Fee> Fees { get; set; }

    [JsonPropertyName("taxes")]
    public List<Tax> Taxes { get; set; }

    [JsonPropertyName("refundableTaxes")]
    public string RefundableTaxes { get; set; }
}

public class AdditionalService
{
    [JsonPropertyName("amount")]
    public string Amount { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}

public class Fee
{
    [JsonPropertyName("amount")]
    public string Amount { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}

public class Tax
{
    [JsonPropertyName("amount")]
    public string Amount { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }
}

public class PricingOptions
{
    [JsonPropertyName("fareType")]
    public List<string> FareType { get; set; }

    [JsonPropertyName("includedCheckedBagsOnly")]
    public bool IncludedCheckedBagsOnly { get; set; }

    [JsonPropertyName("refundableFare")]
    public bool RefundableFare { get; set; }

    [JsonPropertyName("noRestrictionFare")]
    public bool NoRestrictionFare { get; set; }

    [JsonPropertyName("noPenaltyFare")]
    public bool NoPenaltyFare { get; set; }
}

public class TravelerPricing
{
    [JsonPropertyName("travelerId")]
    public string TravelerId { get; set; }

    [JsonPropertyName("fareOption")]
    public string FareOption { get; set; }

    [JsonPropertyName("travelerType")]
    public string TravelerType { get; set; }

    [JsonPropertyName("associatedAdultId")]
    public string AssociatedAdultId { get; set; }

    [JsonPropertyName("price")]
    public Price Price { get; set; }

    [JsonPropertyName("fareDetailsBySegment")]
    public List<FareDetailsBySegment> FareDetailsBySegment { get; set; }
}

public class FareDetailsBySegment
{
    [JsonPropertyName("segmentId")]
    public string SegmentId { get; set; }

    [JsonPropertyName("cabin")]
    public string Cabin { get; set; }

    [JsonPropertyName("fareBasis")]
    public string FareBasis { get; set; }

    [JsonPropertyName("brandedFare")]
    public string BrandedFare { get; set; }

    [JsonPropertyName("class")]
    public string Class { get; set; }

    [JsonPropertyName("isAllotment")]
    public bool IsAllotment { get; set; }

    [JsonPropertyName("sliceDiceIndicator")]
    public string SliceDiceIndicator { get; set; }

    [JsonPropertyName("includedCheckedBags")]
    public BaggageAllowance IncludedCheckedBags { get; set; }

    [JsonPropertyName("additionalServices")]
    public AdditionalServicesRequest AdditionalServices { get; set; }
}

public class BaggageAllowance
{
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    [JsonPropertyName("weightUnit")]
    public string WeightUnit { get; set; }
}

public class AdditionalServicesRequest
{
    [JsonPropertyName("chargeableCheckedBags")]
    public ChargeableCheckedBags ChargeableCheckedBags { get; set; }

    [JsonPropertyName("chargeableSeat")]
    public ChargeableSeat ChargeableSeat { get; set; }

    [JsonPropertyName("chargeableSeatNumber")]
    public string ChargeableSeatNumber { get; set; }

    [JsonPropertyName("otherServices")]
    public List<string> OtherServices { get; set; }
}

public class ChargeableCheckedBags
{
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    [JsonPropertyName("weightUnit")]
    public string WeightUnit { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }
}

public class ChargeableSeat
{
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("number")]
    public string Number { get; set; }
}

public class Dictionaries
{
    [JsonPropertyName("locations")]
    public Dictionary<string, LocationValue> Locations { get; set; }

    [JsonPropertyName("aircraft")]
    public Dictionary<string, string> Aircraft { get; set; }

    [JsonPropertyName("currencies")]
    public Dictionary<string, string> Currencies { get; set; }

    [JsonPropertyName("carriers")]
    public Dictionary<string, string> Carriers { get; set; }
}

public class LocationValue
{
    [JsonPropertyName("cityCode")]
    public string CityCode { get; set; }

    [JsonPropertyName("countryCode")]
    public string CountryCode { get; set; }
}
