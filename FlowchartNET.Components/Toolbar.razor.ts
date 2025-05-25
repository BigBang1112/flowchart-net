declare const htmlToImage: any;

export function toggleTheme(toggle: boolean): void {
    if (toggle) {
        document.body.classList.add("light");
    }
    else {
        document.body.classList.remove("light");
    }
}

export function resetInputFile(input: HTMLInputElement): void {
    input.value = '';
}

export function exportAsImageFormat(format: string): void {
    const workspace = document.getElementById("workspace");
    workspace.style.overflow = "visible";
    const rect = workspace.getBoundingClientRect();
    const absX = rect.left + window.scrollX;
    const absY = rect.top + window.scrollY;
    console.log(rect);

    const leaderLineContainer = document.createElement("div");
    leaderLineContainer.style.position = "absolute";
    leaderLineContainer.style.left = `${-absX}px`;
    leaderLineContainer.style.top = `${-absY}px`;
    workspace.appendChild(leaderLineContainer);

    const workspaceZoom = parseFloat(workspace.style.zoom) || 100;
    const invertedZoom = 100 / workspaceZoom;
    leaderLineContainer.style.zoom = invertedZoom.toString();
    workspace.style.transform = `scale(${invertedZoom})`;

    const leaderLineDefs = document.getElementById("leader-line-defs");
    if (leaderLineDefs) {
        leaderLineContainer.appendChild(leaderLineDefs);
    }

    const lines = document.querySelectorAll('.leader-line');
    lines.forEach((line: Element) => {
        leaderLineContainer.appendChild(line);
    });

    if (format == "png") {
        htmlToImage
            .toPng(workspace, { skipFonts: true })
            .then((dataUrl: string) => {
                var link = document.createElement('a');
                link.download = "test.png";
                link.href = dataUrl;
                link.click();
                link.remove();

                resetAfterExport(workspace, leaderLineDefs, lines, leaderLineContainer);
            });
    }
    else if (format == "jpg") {
        htmlToImage
            .toJpeg(workspace, { skipFonts: true })
            .then((dataUrl: string) => {
                var link = document.createElement('a');
                link.download = "test.jpg";
                link.href = dataUrl;
                link.click();
                link.remove();
                resetAfterExport(workspace, leaderLineDefs, lines, leaderLineContainer);
            });
    }
    else if (format == "svg") {
        htmlToImage
            .toSvg(workspace, { skipFonts: true })
            .then((dataUrl: string) => {
                var link = document.createElement('a');
                link.download = "test.svg";
                link.href = dataUrl;
                link.click();
                link.remove();

                resetAfterExport(workspace, leaderLineDefs, lines, leaderLineContainer);
            });
    }

    function resetAfterExport(
        workspace: HTMLElement,
        leaderLineDefs: HTMLElement | null,
        lines: NodeListOf<Element>,
        leaderLineContainer: HTMLElement
    ): void {
        workspace.style.overflow = "hidden";
        workspace.style.transform = "scale(1)";
        if (leaderLineDefs) {
            document.body.appendChild(leaderLineDefs);
        }
        lines.forEach((line: Element) => {
            document.body.appendChild(line);
        });
        leaderLineContainer.remove();
    }
}