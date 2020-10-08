

import { synthesizeSpeech, synthesizeSpeechStyle, synthesizeSpeechSlow, initSpeech } from "./speech_lib";

export function InitSpeech(key, region) {
    initSpeech(key, region);
}

export function Speak(word) {
    synthesizeSpeech(word);
}


export function SpeakStyle(word, style) {
    synthesizeSpeechStyle(word, style);
}

export function SpeakSlow(word) {
    synthesizeSpeechSlow(word);
}