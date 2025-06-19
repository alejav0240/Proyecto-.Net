function descargarArchivo(base64Data, fileName) {

    console.log(base64Data);
    console.log(fileName);
    var link = document.createElement('a');
    link.href = "data:application/pdf;base64," + base64Data;

    console.log(link.href);

    link.download = fileName;
    link.click();
}
