const config = {
    serverIp: "81.107.155.88",
    serverPort: 3001
};

function getServerAddress() {
    return `ws://${config.serverIp}:${config.serverPort}`;
}

function getServerPath(pathname) {
    return `${getServerAddress()}/${pathname}`;
}

class UserConnection {
    constructor(name, streamId, onMessage) {
        this.name = name;
        this.serverSocket = new WebSocket(getServerPath(`StreamChat/${streamId}`));
        this.serverSocket.onmessage = onMessage;
    }

    send(content) {
        this.serverSocket.send(JSON.stringify({
            Sender: this.name,
            Content: content
        }));
    }
}

const streamsIds = [];

const registerStream = (function() {
    const registerStreamSocket = new WebSocket(getServerPath("RegisterStream"));

    registerStreamSocket.onmessage = function(event) {
        streamsIds.push(event.data);
    };

    return function(id) {
        registerStreamSocket.send(id);
    };
})();

const streamId = "TEST_STREAM";

setTimeout(function() {
    registerStream(streamId);

   setTimeout(function() {
       window.connection = new UserConnection("User", streamId, function(event) {
           console.log(event.data);
       });
   }, 250);
}, 250);