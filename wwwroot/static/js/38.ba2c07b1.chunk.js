(this.webpackJsonpundefined=this.webpackJsonpundefined||[]).push([[38],{169:function(e,s,i){"use strict";i.r(s);const n=async e=>{const s=await e.getFile();return s.handle=e,s};s.default=async(e={})=>{const s=await window.chooseFileSystemEntries({accepts:[{description:e.description||"",mimeTypes:e.mimeTypes||["*/*"],extensions:e.extensions||[""]}],multiple:e.multiple||!1});return e.multiple?Promise.all(s.map(n)):n(s)}}}]);
//# sourceMappingURL=38.ba2c07b1.chunk.js.map