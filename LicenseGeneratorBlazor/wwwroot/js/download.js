window.downloadFileFromStream = async (fileName, contentStreamReference) => {

    const arrayBuffer =
        await contentStreamReference.arrayBuffer();

    const blob = new Blob(
        [arrayBuffer],
        { type: "application/json;charset=utf-8" });

    const url = URL.createObjectURL(blob);

    const anchor = document.createElement("a");

    anchor.href = url;
    anchor.download = fileName ?? "profile.json";

    anchor.click();
    anchor.remove();

    URL.revokeObjectURL(url);
};