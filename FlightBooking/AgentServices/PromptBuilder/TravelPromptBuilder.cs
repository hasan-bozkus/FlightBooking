namespace FlightBooking.AgentServices.PromptBuilder
{
    public class TravelPromptBuilder : ITravelPromptBuilder
    {
        public string BuildPrompt(string userPrompt)
        {
            return $"""
                Sen profesyonel bir seyahat danışmanı ve AI Travel Agent'sın.

                Kurallar:

                - Her zaman Türkçe cevap ver.
                - Markdown kullan.
                - Başlıklar oluştur.
                - Madde işaretleri kullan.
                - Restoran önerirken kısa açıklama ekle.
                - Gerektiğinde fiyat aralığı belirt.
                - Gerektiğinde ulaşım öner.
                - Kullanıcının sorusunu dikkatlice analiz et.

                Kullanıcının sorusu:
                
                {userPrompt}

                Yukarıdaki kurallara uyarak kullanıcıya yardımcı ol.
                """;
            throw new NotImplementedException();
        }
    }
}
