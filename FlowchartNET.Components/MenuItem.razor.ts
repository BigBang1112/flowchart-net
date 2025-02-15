export function addHandlers(button: HTMLElement, symbolId: string): void {
    const img = new Image();
    img.src = "_content/FlowchartNET.Components/img/symbols/" + symbolId + ".webp";
    button.addEventListener('dragstart', (event: DragEvent) => {
        event.dataTransfer.setDragImage(img, img.width / 2, img.height / 2);
        event.dataTransfer.setData("text", symbolId);
    });
}