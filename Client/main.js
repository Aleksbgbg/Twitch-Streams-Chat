const serverSocket = new WebSocket("ws://192.168.0.15:8001/StreamChat");

serverSocket.onmessage = function(event) {
   console.log(`Received message: ${event.data}`);
};