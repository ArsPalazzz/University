const http = require("http");


const port = 8001;
const host = 'localhost';


let h = (r) => {
    let rc = '';
    for (key in r.headers) {
        rc += '<h3>' + key + ':' + r.headers[key] + '</h3>';
    }

    return rc;
}

http.createServer(function (req, res) {
    let b = '';
    req.on('data', str => {b += str; console.log('data', b); })
    res.writeHead(200, { 'Content-Type': 'text/html;charset=utf-8' });
    req.on('end', () => res.end(
        '<!DOCTYPE html><html><head></head>' +
        '<body>' +
        '<h2>' + 'method: ' + req.method + '</h2>' +
        '<h2>' + 'url: ' + req.url + '</h2>' +
        '<h2>' + 'httpVersion: ' + req.httpVersion + '</h2>' +
        '<h2>' + 'headers: ' + h(req) + '</h2>' +
        '<h2>' + 'body: ' + b + '</h2>' +
        '</body>' +
        '</html>'
    ))
}).listen(8001, () => console.log('Server running at http://localhost:8001/'));