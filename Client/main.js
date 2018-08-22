class UserConnection {
    constructor(name, onMessage) {
        this.name = name;
        this.serverSocket = new WebSocket("ws://81.107.155.88:3001/StreamChat");
        this.serverSocket.onmessage = onMessage;
    }

    send(content) {
        this.serverSocket.send(JSON.stringify({
            Sender: this.name,
            Content: content
        }));
    }
}

connection = new UserConnection("User", function(event) {
    console.log(event.data);
});