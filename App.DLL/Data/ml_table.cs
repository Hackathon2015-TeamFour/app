using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DLL.Data
{
    public class ml_table
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool CHF_SEK { get; set; }
        public bool CHF_PLN { get; set; }
        public bool USD_CHF { get; set; }
        public bool GBP_CHF { get; set; }
        public bool SEK_CHF { get; set; }
        public bool DKK_CHF { get; set; }
        public bool JPY_CHF { get; set; }
        public bool GBP_DKK { get; set; }
        public bool SGD_HKD { get; set; }
        public bool AUD_CHF { get; set; }
        public bool USD_UAH { get; set; }
        public bool EUR_CHF { get; set; }
        public bool EUR_GPB { get; set; }
        public bool EUR_AUD { get; set; }
        public bool EUR_SEK { get; set; }
        public bool EUR_PLN { get; set; }
        public bool CHF_EUR { get; set; }
        public bool USD_EUR { get; set; }
        public bool DAX { get; set; }
        public bool SMI { get; set; }
        public bool DJ { get; set; }

        public decimal SIX_Swiss_Exchange { get; set; }
        public decimal UBS_Investment_Bank { get; set; }
        public decimal Zurcher_Kantonalbank_Foreign_Exchange { get; set; }
        public decimal Commerzbank_Frankfurt { get; set; }
        public decimal Dow_Jones_Index_Chicago { get; set; }
        public decimal Osaka_Stock_Exchange_Evening_Session { get; set; }
        public decimal XETRA_Deutsche_Boersen_Indices { get; set; }
        public decimal ICAP_Plc_London_Premium_Spot_Forex { get; set; }
        public decimal Tullett_Prebon_Information_ { get; set; }
        public decimal ICAP_Plc_London_Foreign_Exchange { get; set; }

        public DateTime DateLast_SIX_Swiss_Exchange { get; set; }
        public DateTime DateLast_UBS_Investment_Bank { get; set; }
        public DateTime DateLast_Zurcher_Kantonalbank_Foreign_Exchange { get; set; }
        public DateTime DateLast_Commerzbank_Frankfurt { get; set; }
        public DateTime DateLast_Dow_Jones_Index_Chicago { get; set; }
        public DateTime DateLast_Osaka_Stock_Exchange_Evening_Session { get; set; }
        public DateTime DateLast_XETRA_Deutsche_Boersen_Indices { get; set; }
        public DateTime DateLast_ICAP_Plc_London_Premium_Spot_Forex { get; set; }
        public DateTime DateLast_Tullett_Prebon_Information_ { get; set; }
        public DateTime DateLast_ICAP_Plc_London_Foreign_Exchange { get; set; } 

        public bool Trade { get; set; }
        public bool Bid { get; set; }
        public bool Ask { get; set; }
        public bool Mid { get; set; }
        public bool Issue { get; set; }
        public bool Redemption_Price { get; set; }
        public bool Settlement { get; set; }
        public bool Single_turnover_Off_Market { get; set; }
        public bool Listino { get; set; }
        public bool Open_interest { get; set; }
        public bool Cash { get; set; }
        public bool Annualized_distribution { get; set; }
        public bool Earnings { get; set; }
        public bool Volume { get; set; }
        public bool Turnover { get; set; }
        public bool Historical_Volatility_30_days { get; set; }
        public bool Average_daily_volume { get; set; }
        public bool Historical_Volatility_180_days { get; set; }
        public bool Rolling_calender_year { get; set; }
        public bool Historical_Volatility_90_days { get; set; }
        public bool Part_of_turnover { get; set; }
        public bool Turnover_ON_OFF { get; set; }
        public bool Percentage_Spread_Bid_Ask { get; set; }
        public bool Number_of_trading_days { get; set; }
        public bool Number_of_Ticks { get; set; }
        public bool one_week_average_daily_volatility { get; set; }
        public bool Historical_volatility_year_to_date { get; set; }
        public bool Open { get; set; }
        public bool Last { get; set; }
        public bool Daily_high { get; set; }
        public bool Daily_low { get; set; }
        public bool Derived { get; set; }
        public bool Reference { get; set; }
        public bool Special { get; set; }
        public bool Best { get; set; }
        public bool Valuation_SIX_Financial_Information { get; set; }
        public bool Yield { get; set; }
        public bool Cumulated { get; set; }
        public bool Year_close { get; set; }
        public bool Volatility { get; set; }
        public bool Monthly { get; set; }
        public bool AVG { get; set; }
        public bool AVG_BID { get; set; }


    }
}
