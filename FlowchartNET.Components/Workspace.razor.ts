const main = document.getElementsByTagName('main')[0];

export function addHandlers(dotNetHelper: any): void {
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

export function getMouseX(event: MouseEvent): number {
    const rect = main.getBoundingClientRect();
    return event.clientX - rect.left;
}

export function getMouseY(event: MouseEvent): number {
    const rect = main.getBoundingClientRect();
    return event.clientY - rect.top;
}