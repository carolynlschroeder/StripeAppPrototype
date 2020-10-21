using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeAppPrototype.Dtos
{

    public class CreateInvoiceResponse
    {
        public string id { get; set; }
        public string _object { get; set; }
        public string account_country { get; set; }
        public string account_name { get; set; }
        public object account_tax_ids { get; set; }
        public int amount_due { get; set; }
        public int amount_paid { get; set; }
        public int amount_remaining { get; set; }
        public int? application_fee_amount { get; set; }
        public int attempt_count { get; set; }
        public bool attempted { get; set; }
        public bool auto_advance { get; set; }
        public string billing_reason { get; set; }
        public string charge { get; set; }
        public string collection_method { get; set; }
        public int created { get; set; }
        public string currency { get; set; }
        public object custom_fields { get; set; }
        public string customer { get; set; }
        public object customer_address { get; set; }
        public string customer_email { get; set; }
        public string customer_name { get; set; }
        public string customer_phone { get; set; }
        public object customer_shipping { get; set; }
        public string customer_tax_exempt { get; set; }
        public object[] customer_tax_ids { get; set; }
        public string default_payment_method { get; set; }
        public string default_source { get; set; }
        public object[] default_tax_rates { get; set; }
        public string description { get; set; }
        public object discount { get; set; }
        public object[] discounts { get; set; }
        public string due_date { get; set; }
        public int? ending_balance { get; set; }
        public string footer { get; set; }
        public string hosted_invoice_url { get; set; }
        public string invoice_pdf { get; set; }
        public Lines lines { get; set; }
        public bool livemode { get; set; }
        public Metadata metadata { get; set; }
        public int? next_payment_attempt { get; set; }
        public string number { get; set; }
        public bool paid { get; set; }
        public string payment_intent { get; set; }
        public int period_end { get; set; }
        public int period_start { get; set; }
        public int post_payment_credit_notes_amount { get; set; }
        public int pre_payment_credit_notes_amount { get; set; }
        public string receipt_number { get; set; }
        public int starting_balance { get; set; }
        public object statement_descriptor { get; set; }
        public string status { get; set; }
        public Status_Transitions status_transitions { get; set; }
        public object subscription { get; set; }
        public int subtotal { get; set; }
        public int? tax { get; set; }
        public int total { get; set; }
        public object[] total_discount_amounts { get; set; }
        public object[] total_tax_amounts { get; set; }
        public object transfer_data { get; set; }
        public object webhooks_delivered_at { get; set; }
    }

    public class Lines
    {
        public Datum[] data { get; set; }
        public bool has_more { get; set; }
        public string _object { get; set; }
        public string url { get; set; }
    }

    public class Datum
    {
        public string id { get; set; }
        public string _object { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
        public object[] discount_amounts { get; set; }
        public bool discountable { get; set; }
        public object[] discounts { get; set; }
        public string invoice_item { get; set; }
        public bool livemode { get; set; }
        public Metadata metadata { get; set; }
        public Period period { get; set; }
        public Price price { get; set; }
        public bool proration { get; set; }
        public int quantity { get; set; }
        public object subscription { get; set; }
        public object[] tax_amounts { get; set; }
        public object[] tax_rates { get; set; }
        public string type { get; set; }
    }

    public class Metadata
    {
    }

    public class Period
    {
        public int end { get; set; }
        public int start { get; set; }
    }

    public class Price
    {
        public string id { get; set; }
        public string _object { get; set; }
        public bool active { get; set; }
        public string billing_scheme { get; set; }
        public int created { get; set; }
        public string currency { get; set; }
        public bool livemode { get; set; }
        public object lookup_key { get; set; }
        public Metadata metadata { get; set; }
        public object nickname { get; set; }
        public string product { get; set; }
        public object recurring { get; set; }
        public object tiers_mode { get; set; }
        public object transform_quantity { get; set; }
        public string type { get; set; }
        public int unit_amount { get; set; }
        public string unit_amount_decimal { get; set; }
    }


    public class Status_Transitions
    {
        public object finalized_at { get; set; }
        public object marked_uncollectible_at { get; set; }
        public object paid_at { get; set; }
        public object voided_at { get; set; }
    }

}
