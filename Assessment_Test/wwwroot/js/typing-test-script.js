let startTime;
let finishedTyping = false;

function calculateWPM() {
    if (finishedTyping) return;

    const userInput = document.getElementById("user-input").value;
    const generatedText = document.getElementById("generated-paragraph").value;
    const wordCount = userInput.split(/\s+/).length;
    const characterCount = userInput.length;

    if (!startTime) {
        startTime = new Date();
    }

    const elapsedTime = (new Date() - startTime) / 60000; // Time in minutes
    const wpm = Math.round(wordCount / elapsedTime);
    document.getElementById("wpm").textContent = wpm;

    const accuracy = calculateAccuracy(generatedText, userInput);
    document.getElementById("accuracy").textContent = accuracy.toFixed(2); // Round to two decimal places

    if (userInput === generatedText) {
        finishedTyping = true; // Stops the WPM calculation
    }
}

function calculateAccuracy(originalText, typedText) {
    const originalWords = originalText.trim().split(/\s+/);
    const typedWords = typedText.trim().split(/\s+/);
    const minLength = Math.min(originalWords.length, typedWords.length);
    let errorCount = 0;

    for (let i = 0; i < minLength; i++) {
        if (originalWords[i] !== typedWords[i]) {
            errorCount++;
        }
    }

    // Include any extra words typed as errors
    if (typedWords.length > originalWords.length) {
        errorCount += typedWords.length - originalWords.length;
    }

    const accuracy = ((minLength - errorCount) / originalWords.length) * 100;
    return accuracy;


    function startTest() {
        // Enable the user input textarea
        document.getElementById('user-input').disabled = false;
        // Focus on the input area to start typing
        document.getElementById('user-input').focus();
        // Hide the start button to prevent re-starting
        document.getElementById('start-btn').style.display = 'none';
        // Initialize any timers or events for starting the test
        // ...
    }

    function cancelTest() {
        // Clear the user input textarea
        document.getElementById('user-input').value = '';
        // Disable the user input textarea
        document.getElementById('user-input').disabled = true;
        // Show the start button again
        document.getElementById('start-btn').style.display = 'inline-block';
        // Reset WPM and accuracy display
        document.getElementById('wpm').textContent = '0';
        document.getElementById('accuracy').textContent = '100';
        // Reset any timers or events related to the test
        // ...
    }

}
