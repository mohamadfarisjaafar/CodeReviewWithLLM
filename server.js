const express = require('express');
const fetch = require('node-fetch');
const app = express();
const port = 3000;

app.use(express.json()); // Middleware to parse JSON

// Endpoint to receive code review request from the frontend
app.post('/review', async (req, res) => {
    const { code } = req.body;

    try {
        const response = await fetch('http://localhost:5000/api/review', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ code }),
        });

        const data = await response.json();
        res.json({ feedback: data.feedback });
    } catch (error) {
        console.error('Error during code review:', error);
        res.status(500).json({ error: 'Failed to review code' });
    }
});

app.listen(port, () => {
    console.log(`Backend server is running at http://localhost:${port}`);
});
