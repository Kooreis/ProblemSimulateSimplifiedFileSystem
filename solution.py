def ls(self, path: str):
        if path in self.filepath:
            if isinstance(self.filepath[path], str):
                return [path.split('/')[-1]]
            return sorted(self.filepath[path].keys())
        else:
            path = path.split('/')
            node = self.filepath
            for part in path[1:]:
                node = node[part]
            return sorted(node.keys())