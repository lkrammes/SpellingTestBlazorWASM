/// <reference path="../../wwwroot/js/microsoft.cognitiveservices.speech.sdk.bundle.js" />
var sdk = require("microsoft-cognitiveservices-speech-sdk");
var speechConfig;
var audioConfig;
var synthesizer;

export function initSpeech(key, region) {
    speechConfig = sdk.SpeechConfig.fromSubscription(key, region);
    audioConfig = sdk.AudioConfig.fromDefaultSpeakerOutput();
    synthesizer = new sdk.SpeechSynthesizer(speechConfig, audioConfig);
}

export function synthesizeSpeech(output) {

    var speech = `<speak version="1.0" xmlns="https://www.w3.org/2001/10/synthesis" xml:lang="en-US"><voice name="en-US-AriaNeural">${output}</voice></speak>`;

    synthesizer.speakSsmlAsync(speech);
}

export function synthesizeSpeechStyle(output, style) {

    var speech = `<speak version="1.0" xmlns="http://www.w3.org/2001/10/synthesis"
    xmlns:mstts="https://www.w3.org/2001/mstts" xml:lang="en-US">
  <voice name="en-US-AriaNeural">
    <mstts:express-as style="${style}">
      ${output}!
 </mstts:express-as>
  </voice>
</speak>`;

    synthesizer.speakSsmlAsync(speech);
}

export function synthesizeSpeechSlow(output) {

    var speech = `<speak version="1.0" xmlns="https://www.w3.org/2001/10/synthesis" xml:lang="en-US"><voice name="en-US-AriaNeural"><prosody rate="-25.00%">${output}</prosody></voice></speak>`;

    synthesizer.speakSsmlAsync(speech);
}


//on any updates to this file run this before build
//C:\Users\Lucas\source\Workspaces\Holeshot Software\SpellingTestBlazorWASM\SpellingTestBlazorWASM\Client\JSLib>npm run build
//https://medium.com/swlh/using-npm-packages-with-blazor-2b0310279320