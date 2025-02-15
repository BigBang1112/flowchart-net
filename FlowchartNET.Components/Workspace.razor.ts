export function addHandlers(dotNetHelper: any): void {
    const main = document.getElementsByTagName('main')[0];
    main.addEventListener('drop', (event: DragEvent) => {
        event.preventDefault();

        const symbolId = event.dataTransfer.getData("text");

        if (symbolId === '') {
            return;
        }

        const rect = main.getBoundingClientRect();

        // Calculate the mouse position relative to the element
        const x = event.clientX - rect.left;
        const y = event.clientY - rect.top;

        dotNetHelper.invokeMethodAsync('AddSymbol', symbolId, x, y);
    });
}