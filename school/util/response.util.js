module.exports = {
    Send: function (res, numberResponse, result, message, href, functionName) {
        if (numberResponse == null && (numberResponse != 200 && numberResponse != 400)) {
            throw Error("numberResponse is required");
        }
        
        const buildResponse = { "result": result, "message": message, "href": href, "function": functionName };
        res.status(numberResponse).send(JSON.stringify(buildResponse));
    }
}