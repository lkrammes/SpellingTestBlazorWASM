namespace SpellingTestBlazor.Client.Services.Services
{
    #region using

    using System;
    using System.Threading.Tasks;
    using Microsoft.CognitiveServices.Speech;

    #endregion


    public sealed class SpeechService : IDisposable
    {
        private readonly SpeechSynthesizer _speechSynthesizer;

        public SpeechService()
        {
            SpeechConfig config = SpeechConfig.FromSubscription("d6fd91a3cfcc411080e0706584881168", "eastus");
            _speechSynthesizer = new SpeechSynthesizer(config);
        }

        public void Dispose()
        {
            _speechSynthesizer?.Dispose();
        }

        public async Task SpeakAsync(string output)
        {
            var speech = $@"
<speak version=""1.0"" xmlns=""https://www.w3.org/2001/10/synthesis"" xml:lang=""en-US"">
  <voice name=""en-US-AriaNeural"">
    {output}
  </voice>
</speak>
 ";

            await _speechSynthesizer.SpeakSsmlAsync(speech);
        }

        public async Task SpeakStyle(string output, string style)
        {
            var speech = $@"
<speak version=""1.0"" xmlns=""http://www.w3.org/2001/10/synthesis""
       xmlns:mstts=""https://www.w3.org/2001/mstts"" xml:lang=""en-US"">
    <voice name=""en-US-AriaNeural"">
        <mstts:express-as style=""{style}"">
            {output}!
        </mstts:express-as>
    </voice>
</speak>
             ";

            await _speechSynthesizer.SpeakSsmlAsync(speech);
        }

        public async Task SpeakSlow(string output)
        {
            var speech = $@"
<speak version=""1.0"" xmlns=""https://www.w3.org/2001/10/synthesis"" xml:lang=""en-US"">
  <voice name=""en-US-AriaNeural"">
   <prosody rate=""-25.00%"">
           {output}
        </prosody>
  
    </voice>
</speak>
 ";

            await _speechSynthesizer.SpeakSsmlAsync(speech);
        }
    }
}
