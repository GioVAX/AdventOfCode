// --- Day 1: Chronal Calibration ---
// "We've detected some temporal anomalies," one of Santa's Elves at the Temporal Anomaly Research and Detection Instrument Station tells you. She sounded pretty worried when she called you down here. "At 500-year intervals into the past, someone has been changing Santa's history!"
// "The good news is that the changes won't propagate to our time stream for another 25 days, and we have a device" - she attaches something to your wrist - "that will let you fix the changes with no such propagation delay. It's configured to send you 500 years further into the past every few days; that was the best we could do on such short notice."
// "The bad news is that we are detecting roughly fifty anomalies throughout time; the device will indicate fixed anomalies with stars. The other bad news is that we only have one device and you're the best person for the job! Good lu--" She taps a button on the device and you suddenly feel like you're falling. To save Christmas, you need to get all fifty stars by December 25th.
// Collect stars by solving puzzles. Two puzzles will be made available on each day in the advent calendar; the second puzzle is unlocked when you complete the first. Each puzzle grants one star. Good luck!
// After feeling like you've been falling for a few minutes, you look at the device's tiny screen. "Error: Device must be calibrated before first use. Frequency drift detected. Cannot maintain destination lock." Below the message, the device shows a sequence of changes in frequency (your puzzle input). A value like +6 means the current frequency increases by 6; a value like -3 means the current frequency decreases by 3.
// For example, if the device displays frequency changes of +1, -2, +3, +1, then starting from a frequency of zero, the following changes would occur:
// Current frequency  0, change of +1; resulting frequency  1.
// Current frequency  1, change of -2; resulting frequency -1.
// Current frequency -1, change of +3; resulting frequency  2.
// Current frequency  2, change of +1; resulting frequency  3.
// In this example, the resulting frequency is 3.
// Here are other example situations:
// +1, +1, +1 results in  3
// +1, +1, -2 results in  0
// -1, -2, -3 results in -6
// Starting with a frequency of zero, what is the resulting frequency after all of the changes in frequency have been applied?

let freqChanges = Array.toList [| +11 ; +16 ; +2 ; -16 ; -6 ; +13 ; -6 ; -8 ; -17 ; +15 ; -11 ; -14 ; +17 ; -9 ; +4 ; +1 ; -15 ; -17 ; -8 ; +16 ; +6 ; -11 ; -15 ; -2 ; +3 ; -6 ; -2 ; -4 ; -2 ; -18 ; -6 ; -2 ; +18 ; -4 ; +7 ; +15 ; -11 ; +8 ; -4 ; -17 ; -19 ; -15 ; -17 ; -7 ; +12 ; -2 ; -5 ; -13 ; -4 ; -13 ; -18 ; +16 ; +12 
    ; +10 ; +14 ; -19 ; +13 ; +10 ; +8 ; -10 ; +3 ; -16 ; -7 ; -9 ; -19 ; -15 ; -19 ; +2 ; +7 ; -1 ; +7 ; +1 ; -20 ; -5 ; -10 ; +14 ; +10 ; +5 ; +13 ; +10 ; +15 ; +3 ; -16 ; -17 ; +19 ; +15 ; +2 ; +14 ; -11 ; +3 ; -11 ; -17 ; -8 ; +16 ; -13 ; -1 ; +16 ; +1 ; +12 ; -5 ; +20 ; +16 ; +10 ; -9 ; -8 ; +15 ; -4 ; +3 
    ; +5 ; +7 ; +1 ; -2 ; +19 ; +14 ; -5 ; -10 ; -4 ; +3 ; +18 ; -15 ; +17 ; -7 ; +10 ; -8 ; -10 ; +4 ; +10 ; +12 ; +11 ; -4 ; -4 ; -8 ; +11 ; +16 ; -4 ; +14 ; +2 ; +3 ; -16 ; +19 ; -9 ; +5 ; +17 ; +19 ; -17 ; -4 ; +13 ; +15 ; -6 ; +20 ; +12 ; +15 ; -17 ; +13 ; -7 ; -14 ; +11 ; +12 ; -10 ; +16 ; -10 ; +8 ; +11 
    ; -8 ; +16 ; +5 ; +3 ; -4 ; +15 ; -16 ; +4 ; +2 ; +5 ; +8 ; +12 ; +7 ; +8 ; +4 ; +19 ; -14 ; +2 ; +8 ; +12 ; -14 ; +19 ; +15 ; -14 ; -17 ; -5 ; +7 ; -20 ; -5 ; -4 ; +14 ; -21 ; +4 ; -8 ; -7 ; +14 ; -18 ; -7 ; -18 ; -13 ; -19 ; -8 ; +16 ; +3 ; -8 ; +14 ; +10 ; +9 ; +18 ; -15 ; +14 ; -1 ; +18 ; +15 ; +17 ; +11 
    ; +16 ; -11 ; +7 ; -13 ; -14 ; -6 ; -11 ; +13 ; -12 ; -2 ; +9 ; -12 ; +10 ; -18 ; -6 ; -8 ; +9 ; +3 ; +6 ; +11 ; +15 ; +15 ; +5 ; +19 ; +15 ; +8 ; -12 ; -17 ; -8 ; +19 ; +2 ; +9 ; +2 ; +6 ; -10 ; -22 ; -9 ; +19 ; -5 ; -4 ; +3 ; +14 ; -1 ; -20 ; +15 ; +17 ; -1 ; +19 ; -8 ; +11 ; -13 ; +17 ; +9 ; +9 ; +18 ; +7 
    ; -8 ; +11 ; +16 ; +9 ; -1 ; +15 ; +19 ; -25 ; +1 ; -6 ; +8 ; -4 ; +13 ; -23 ; +15 ; +3 ; -14 ; +1 ; +25 ; +51 ; -11 ; +5 ; +5 ; -13 ; +17 ; +13 ; +16 ; +17 ; +17 ; +18 ; +16 ; +16 ; -5 ; -20 ; -19 ; +15 ; -14 ; -15 ; -6 ; +9 ; -1 ; -5 ; -13 ; -24 ; +13 ; -18 ; -29 ; +3 ; +10 ; -14 ; +29 ; -21 ; +11 ; +13 
    ; +24 ; +23 ; -17 ; +19 ; -1 ; -7 ; -5 ; +20 ; +5 ; -11 ; +3 ; -20 ; -13 ; +5 ; -12 ; -8 ; +4 ; -23 ; -31 ; +18 ; -50 ; -27 ; -16 ; +15 ; -21 ; -26 ; -11 ; -46 ; -11 ; -12 ; -5 ; -1 ; -6 ; +3 ; +19 ; +7 ; +33 ; +9 ; +11 ; +14 ; +32 ; +36 ; +15 ; -92 ; +22 ; -19 ; -18 ; -8 ; -24 ; +28 ; -72 ; +15 ; -19 ; -34 
    ; -4 ; -11 ; -4 ; +17 ; +14 ; -26 ; -23 ; -18 ; -10 ; -1 ; +39 ; -5 ; +19 ; +16 ; +26 ; -25 ; -40 ; -11 ; +19 ; -11 ; +1 ; +7 ; -55 ; -21 ; +73 ; +503 ; +843 ; +54936 ; +14 ; -12 ; +13 ; -7 ; -11 ; +8 ; +11 ; +11 ; +7 ; +13 ; +12 ; +9 ; +12 ; +1 ; +7 ; -19 ; -3 ; -5 ; -1 ; -20 ; +12 ; +11 ; -10 ; -8 ; -6 
    ; +17 ; +19 ; +1 ; +10 ; -19 ; +4 ; +19 ; +6 ; +4 ; +3 ; +6 ; +4 ; +12 ; +3 ; +2 ; -9 ; +3 ; +9 ; -15 ; -10 ; -9 ; -10 ; +4 ; +19 ; +11 ; +19 ; +2 ; +5 ; +9 ; -15 ; +12 ; +5 ; +9 ; +18 ; -12 ; -4 ; +7 ; +13 ; -6 ; +16 ; +16 ; +12 ; -7 ; +18 ; +3 ; +15 ; -12 ; +8 ; -19 ; +3 ; +3 ; +11 ; -3 ; +17 ; -10 ; +3 ; -20 ; +6 
    ; -17 ; +9 ; +16 ; +18 ; +8 ; -10 ; -12 ; +13 ; +7 ; -2 ; -11 ; +10 ; -2 ; +1 ; -5 ; +10 ; +13 ; -7 ; +14 ; +17 ; -1 ; -1 ; +8 ; -4 ; +16 ; -3 ; +16 ; +17 ; +4 ; +13 ; -3 ; +8 ; -15 ; -12 ; +14 ; +16 ; -5 ; -7 ; +14 ; -12 ; -17 ; -21 ; -1 ; -16 ; +4 ; +7 ; -14 ; -12 ; +16 ; -12 ; -12 ; -8 ; -3 ; -2 ; -4 ; +16 ; -14 
    ; +8 ; +18 ; -8 ; -2 ; -13 ; +2 ; +17 ; +15 ; +13 ; +12 ; -4 ; +19 ; -8 ; -6 ; +5 ; -16 ; +14 ; -15 ; -18 ; +13 ; +19 ; -9 ; +23 ; -5 ; -7 ; +5 ; +12 ; +18 ; -1 ; +20 ; -7 ; -6 ; -9 ; -11 ; +6 ; -5 ; +1 ; +7 ; +14 ; -2 ; +7 ; +2 ; +14 ; -3 ; -9 ; +15 ; -2 ; +12 ; +4 ; -5 ; +8 ; +9 ; -4 ; +2 ; +13 ; -4 ; -4 ; -10 ; +4 ; -2 
    ; +13 ; -2 ; -12 ; +26 ; +2 ; +17 ; +20 ; +20 ; +5 ; -21 ; +12 ; -5 ; -14 ; +4 ; +12 ; +9 ; -14 ; -1 ; +10 ; -5 ; -14 ; -5 ; -17 ; -12 ; -8 ; +12 ; +11 ; -9 ; +18 ; +2 ; -12 ; +7 ; +6 ; -8 ; +6 ; -18 ; -21 ; -8 ; +1 ; +12 ; -25 ; -11 ; +4 ; -16 ; -10 ; +19 ; +12 ; -10 ; -1 ; -24 ; -7 ; +4 ; +9 ; -4 ; -19 ; +28 ; +1 
    ; +5 ; -8 ; -18 ; +8 ; -29 ; -26 ; -17 ; +4 ; -19 ; -8 ; -6 ; +8 ; +15 ; +36 ; -6 ; -5 ; -18 ; +6 ; -4 ; -19 ; -4 ; -11 ; +3 ; -16 ; -1 ; +2 ; +13 ; +21 ; -10 ; +32 ; +28 ; +5 ; +21 ; -36 ; -11 ; -90 ; -11 ; +17 ; -11 ; +10 ; +3 ; +2 ; +11 ; -25 ; -17 ; -9 ; -9 ; +20 ; -17 ; -19 ; -17 ; -1 ; +6 ; -2 ; +10 ; -12 
    ; +5 ; -9 ; +12 ; +16 ; +3 ; -18 ; +1 ; +15 ; -3 ; -8 ; +15 ; +18 ; +11 ; +5 ; -20 ; -12 ; +6 ; -3 ; -13 ; +19 ; -17 ; +19 ; -23 ; +1 ; -14 ; +20 ; +13 ; +7 ; +3 ; -21 ; -17 ; -23 ; -8 ; -18 ; +16 ; +5 ; +7 ; -6 ; -9 ; -19 ; -18 ; +17 ; +17 ; -22 ; +17 ; +15 ; -12 ; -9 ; -9 ; +14 ; -9 ; -9 ; +3 ; -8 ; -7 ; -23 
    ; +7 ; +22 ; +37 ; +14 ; +22 ; -20 ; -9 ; -23 ; +18 ; -8 ; -5 ; +9 ; -13 ; +25 ; +8 ; -28 ; +23 ; -39 ; -8 ; -51 ; -30 ; +3 ; -31 ; +1 ; +4 ; +172 ; +17 ; +18 ; -30 ; +18 ; +47 ; +19 ; -24 ; -14 ; +117 ; -5 ; +168 ; +14 ; -16 ; -61 ; +1728 ; +54439 ; -8 ; +15 ; +5 ; -2 ; -1 ; -12 ; -3 ; +10 ; +15 ; +10 
    ; -14 ; +15 ; -8 ; +11 ; +10 ; -12 ; +11 ; +12 ; +17 ; -10 ; -6 ; -19 ; -19 ; +18 ; -12 ; -3 ; -7 ; -11 ; -13 ; -10 ; +9 ; -13 ; +9 ; -15 ; +16 ; +2 ; +16 ; +13 ; -17 ; +19 ; +16 ; +16 ; -10 ; -12 ; -7 ; +5 ; -15 ; +14 ; +19 ; -12 ; +17 ; +8 ; -18 ; +17 ; -4 ; +1 ; +6 ; -13 ; -5 ; +23 ; -19 ; -8 ; -13 ; -31 
    ; -12 ; -3 ; +5 ; -3 ; +11 ; -1 ; -20 ; -8 ; +5 ; -2 ; -2 ; -18 ; +1 ; -19 ; -5 ; -3 ; +13 ; +15 ; +10 ; -8 ; -14 ; +16 ; -14 ; +18 ; -11 ; +6 ; -10 ; -4 ; +5 ; -15 ; +8 ; -17 ; -7 ; -12 ; -12 ; +10 ; +6 ; -12 ; -17 ; +1 ; +8 ; +17 ; +17 ; -11 ; +19 ; -18 ; +1 ; -14 ; -2 ; -15 ; -6 ; -1 ; -16 ; +1 ; -3 ; +6 ; -18 
    ; +1 ; -17 ; +8 ; +19 ; +18 ; -5 ; +12 ; +6 ; -15 ; +19 ; -8 ; -16 ; +18 ; +15 ; -6 ; +1 ; -17 ; -10 ; -4 ; -112437 |];;

let answ1 = List.sum freqChanges;;

// --- Part Two ---
// You notice that the device repeats the same frequency change list over and over. To calibrate the device, you need to find the first frequency it reaches twice.
// For example, using the same list of changes above, the device would loop as follows:
// Current frequency  0, change of +1; resulting frequency  1.
// Current frequency  1, change of -2; resulting frequency -1.
// Current frequency -1, change of +3; resulting frequency  2.
// Current frequency  2, change of +1; resulting frequency  3.
// (At this point, the device continues from the start of the list.)
// Current frequency  3, change of +1; resulting frequency  4.
// Current frequency  4, change of -2; resulting frequency  2, which has already been seen.
// In this example, the first frequency reached twice is 2. Note that your device might need to repeat its list of frequency changes many times before a duplicate frequency is found, and that duplicates might be found while in the middle of processing the list.

// Here are other examples:
// +1, -1 first reaches 0 twice.
// +3, +3, +4, -2, -4 first reaches 10 twice.
// -6, +3, +8, +5, -6 first reaches 5 twice.
// +7, +7, -2, -7, -4 first reaches 14 twice.

// What is the first frequency your device reaches twice?
let findRepetition (currFreq:int) changsList =
    let rec findRepetition' met (currFreq:int) changes = 
        match changes with
        | [] -> findRepetition' met currFreq changsList
        | chg::rest -> 
            let newFreq = chg + currFreq
            // printf "%i " newFreq
            if Set.contains newFreq met then 
                Some newFreq 
                else findRepetition' (Set.add newFreq met) newFreq rest
    findRepetition' (Set.empty.Add(0)) currFreq changsList;;

let testAnsw1 = findRepetition 0 [+1; -1];;
let testAnsw2 = findRepetition  0 [+3; +3; +4; -2; -4];;
let testAnsw3 = findRepetition  0 [-6; +3; +8; +5; -6];;
let testAnsw4 = findRepetition  0 [+7; +7; -2; -7; -4];;
let answ2 = findRepetition  0 freqChanges;;