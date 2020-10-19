window.webviewerFunctions = {
    initWebViewer: function () {
        const viewerElement = document.getElementById('viewer');
        WebViewer({
            path: 'lib',
            initialDoc: '../files/resume.pdf', // replace with your own PDF file
        }, viewerElement).then((instance) => {
            // call apis here
        })
    }
};