window.typeGraph = {
    _cy: null,

    init: function (nodes, edges) {
        const container = document.getElementById('typeGraph');
        if (!container) return;
        if (this._cy) {
            this._cy.destroy();
        }

        this._cy = cytoscape({
            container: container,
            elements: {
                nodes: nodes.map(n => ({
                    data: { id: n.id, label: n.label, color: n.color, isCenter: n.isCenter }
                })),
                edges: edges.map(e => ({
                    data: {
                        id: e.id,
                        source: e.source,
                        target: e.target,
                        edgeColor: e.edgeColor,
                        label: e.label
                    }
                }))
            },
            style: [
                {
                    selector: 'node',
                    style: {
                        'background-color': 'data(color)',
                        'label': 'data(label)',
                        'color': '#fff',
                        'text-valign': 'center',
                        'text-halign': 'center',
                        'font-size': '11px',
                        'font-weight': 'bold',
                        'width': '75px',
                        'height': '75px',
                        'text-outline-color': 'data(color)',
                        'text-outline-width': '2px',
                        'border-width': '2px',
                        'border-color': 'rgba(255,255,255,0.4)'
                    }
                },
                {
                    selector: 'node[?isCenter]',
                    style: {
                        'width': '92px',
                        'height': '92px',
                        'font-size': '13px',
                        'border-width': '4px',
                        'border-color': '#fff'
                    }
                },
                {
                    selector: 'edge',
                    style: {
                        'line-color': 'data(edgeColor)',
                        'target-arrow-color': 'data(edgeColor)',
                        'target-arrow-shape': 'triangle',
                        'curve-style': 'bezier',
                        'width': 4,
                        'arrow-scale': 1.6,
                        'label': 'data(label)',
                        'font-size': '12px',
                        'font-weight': 'bold',
                        'color': 'data(edgeColor)',
                        'text-background-color': '#fff',
                        'text-background-opacity': 0.8,
                        'text-background-padding': '3px'
                    }
                }
            ],
            layout: {
                name: 'concentric',
                concentric: node => node.data('isCenter') ? 10 : 1,
                levelWidth: () => 1,
                minNodeSpacing: 60,
                animate: true,
                animationDuration: 400
            }
        });
    }
};