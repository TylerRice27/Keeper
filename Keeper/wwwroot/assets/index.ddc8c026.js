var ie=Object.defineProperty;var L=Object.getOwnPropertySymbols;var le=Object.prototype.hasOwnProperty,de=Object.prototype.propertyIsEnumerable;var B=(a,e,o)=>e in a?ie(a,e,{enumerable:!0,configurable:!0,writable:!0,value:o}):a[e]=o,U=(a,e)=>{for(var o in e||(e={}))le.call(e,o)&&B(a,o,e[o]);if(L)for(var o of L(e))de.call(e,o)&&B(a,o,e[o]);return a};import{r as D,c as h,a as x,o as _,b as p,d as s,e as g,w as y,F,f as S,t as f,S as z,g as ue,h as j,i as H,M as K,j as k,v as $,k as A,u as q,n as Y,l as _e,m as pe,p as G,q as me,s as W,x as ve,y as Q,z as E,A as P,B as ge,C as fe,D as J,E as he,G as be}from"./vendor.f59b7483.js";const ye=function(){const e=document.createElement("link").relList;if(e&&e.supports&&e.supports("modulepreload"))return;for(const r of document.querySelectorAll('link[rel="modulepreload"]'))t(r);new MutationObserver(r=>{for(const i of r)if(i.type==="childList")for(const n of i.addedNodes)n.tagName==="LINK"&&n.rel==="modulepreload"&&t(n)}).observe(document,{childList:!0,subtree:!0});function o(r){const i={};return r.integrity&&(i.integrity=r.integrity),r.referrerpolicy&&(i.referrerPolicy=r.referrerpolicy),r.crossorigin==="use-credentials"?i.credentials="include":r.crossorigin==="anonymous"?i.credentials="omit":i.credentials="same-origin",i}function t(r){if(r.ep)return;r.ep=!0;const i=o(r);fetch(r.href,i)}};ye();const c=D({user:{},account:{},keeps:[],profileKeeps:[],activeKeep:{},vaults:[],myVaults:[],profileVaults:[],activeProfile:{},vaultKeeps:[],activeVault:{}});var w=(a,e)=>{for(const[o,t]of e)a[o]=t;return a};const ke={name:"App",setup(){return{activeKeep:h(()=>c.activeKeep),appState:h(()=>c)}}},we={class:"bg-secondary"},xe=S("Create Keep"),Ke=S("Create Vault"),Ve=S("Edit Account");function $e(a,e,o,t,r,i){const n=x("Navbar"),v=x("router-view"),d=x("KepForm"),V=x("Modal"),se=x("VaultForm"),ne=x("AccountForm"),re=x("KepModal"),ce=x("VaultModal");return _(),p(F,null,[s("header",null,[g(n)]),s("main",we,[g(v),g(V,{id:"create-keep"},{header:y(()=>[xe]),body:y(()=>[g(d)]),_:1}),g(V,{id:"create-vault"},{header:y(()=>[Ke]),body:y(()=>[g(se)]),_:1}),g(V,{id:"editAccount-form"},{header:y(()=>[Ve]),body:y(()=>[g(ne)]),_:1}),g(V,{id:"keep-details"},{header:y(()=>[S(f(t.activeKeep.name),1)]),body:y(()=>[g(re)]),_:1}),g(V,{id:"vault-details"},{header:y(()=>[S(f(t.activeKeep.name),1)]),body:y(()=>[g(ce)]),_:1})])],64)}var Se=w(ke,[["render",$e]]);const X=window.location.origin.includes("localhost"),Z=X?"https://localhost:5001":"",Te="dev-ukxg-q38.us.auth0.com",Ae="OrNg1n6swOJ7RGMg8DMDMQMPRnqipYnu",Ce="https://TylerDev.com";function C(a,e){if(X)console[a](`[${a}] :: ${new Date().toLocaleTimeString()} :: `,...e);else{switch(a){case"log":case"assert":return}console[a](`[${a}] :: ${new Date().toLocaleTimeString()} :: `,...e)}}const l={log(){C("log",arguments)},error(){C("error",arguments)},warn(){C("warn",arguments)},assert(){C("assert",arguments)},trace(){C("trace",arguments)}};class u{static async confirm(e="Are you sure?",o="You won't be able to revert this!",t="warning",r="Yes, delete it!"){try{return!!(await z.fire({title:e,text:o,icon:t,showCancelButton:!0,confirmButtonColor:"#3085d6",cancelButtonColor:"#d33",confirmButtonText:r})).isConfirmed}catch{return!1}}static toast(e="Warning!",o="warning",t="top-end",r=3e3,i=!0){z.fire({title:e,icon:o,position:t,timer:r,timerProgressBar:i,toast:!0,showConfirmButton:!1})}static error(e){var o;if(e.isAxiosError){const{response:t}=e;this.toast(((o=t.data.error)==null?void 0:o.message)||t.data.message,"error")}else this.toast(e.message||e,"error")}static success(e="Success!"){this.toast(e,"success")}}const m=ue.create({baseURL:Z,timeout:8e3});class Ee{async getAccount(){try{const e=await m.get("/account");c.account=e.data}catch(e){l.error("HAVE YOU STARTED YOUR SERVER YET???",e)}}async editAccount(e){try{const o=await m.put("/account",e);l.log(o.data),c.account=o.data}catch{}}async getMyVaults(){try{const e=await m.get("/account/vaults");c.myVaults=e.data}catch(e){l.error(e),u.toast(e.message,"error")}}}const R=new Ee,Pe={setup(){const a=j({});return H(()=>{c.account,a.value=U({},c.account)}),{editable:a,account:h(()=>c.account),async editAccount(){try{await R.editAccount(a.value),K.getOrCreateInstance(document.getElementById("editAccount-form")).hide()}catch(e){l.error(e),u.toast(e.message,"error")}}}}},Ie={class:"mb-3"},Oe=s("label",null,"Account Name",-1),Me={class:"mb-3"},De=s("label",null,"Account Image",-1),je=s("button",{class:"btn btn-primary"},"Save Changes!",-1);function qe(a,e,o,t,r,i){return _(),p("form",{class:"m-2",onSubmit:e[2]||(e[2]=A((...n)=>t.editAccount&&t.editAccount(...n),["prevent"])),id:"editAccount-form"},[s("div",Ie,[Oe,k(s("input",{class:"form-control","onUpdate:modelValue":e[0]||(e[0]=n=>t.editable.name=n),type:"text",required:""},null,512),[[$,t.editable.name]])]),s("div",Me,[De,k(s("input",{class:"form-control","onUpdate:modelValue":e[1]||(e[1]=n=>t.editable.picture=n),type:"text",required:""},null,512),[[$,t.editable.picture]])]),je],32)}var Re=w(Pe,[["render",qe]]),Ne=Object.freeze({__proto__:null,[Symbol.toStringTag]:"Module",default:Re});class Le{async getAll(){const e=await m.get("api/keeps");c.keeps=e.data}async setActive(e){const o=await m.get(`api/keeps/${e.id}`);l.log("open this keep modal",o.data),c.activeKeep=e,e.views++}async createKeep(e){const o=await m.post("api/keeps",e);return l.log("Create a Keep",o.data),c.profileKeeps.unshift(o.data),o.data}async deleteKeep(e){const o=await m.delete("api/keeps/"+e);l.log("Delete this keep",o.data),c.keeps=c.keeps.filter(t=>t.id!=e)}}const I=new Le;const Be={props:{keep:{type:Object,required:!0}},setup(a){const e=q();return{goToProfile(){K.getOrCreateInstance(document.getElementById("keep-details")).hide(),e.push({name:"Profile",params:{id:a.keep.creator.id}})},async setActive(){var o;try{I.setActive(a.keep),((o=a.keep)==null?void 0:o.vaultKeepId)||K.getOrCreateInstance(document.getElementById("keep-details")).show()}catch(t){u.toast("Something went wrong","error"),l.error(t)}}}}},Ue={class:""},Fe={class:"text-light d-flex justify-content-between keep-text"},ze=["title","src"];function He(a,e,o,t,r,i){var n,v;return _(),p("div",{class:"p-2 kep-hover card elevation-3 bg-secondary selectable lighten-20 d-flex justify-content-end",onClick:e[1]||(e[1]=(...d)=>t.setActive&&t.setActive(...d)),style:Y(`background-image: url(${o.keep.img});`)},[s("div",Ue,[s("h5",Fe,[S(f(o.keep.name),1),s("img",{class:"profile-pic rounded-pill",onClick:e[0]||(e[0]=A((...d)=>t.goToProfile&&t.goToProfile(...d),["stop"])),title:(n=o.keep.creator)==null?void 0:n.name,src:(v=o.keep.creator)==null?void 0:v.picture,alt:""},null,8,ze)])])],4)}var Ye=w(Be,[["render",He],["__scopeId","data-v-b75910e4"]]),Ge=Object.freeze({__proto__:null,[Symbol.toStringTag]:"Module",default:Ye});const We={setup(){const a=j({});return{editable:a,async createKeep(){try{const e=await I.createKeep(a.value);K.getOrCreateInstance(document.getElementById("create-keep")).hide(),a.value={},u.toast("Keep Created!")}catch(e){u.error(e)}}}}},Qe={class:"mb-3 text-black"},Je=s("label",null,"Keep Title",-1),Xe={class:"mb-3 text-black"},Ze=s("label",null,"Keep Picture",-1),et={class:"mb-3 text-black"},tt=s("label",null,"Keep Description",-1),ot=s("button",{class:"btn btn-primary m-1"},"Create Keep!",-1);function at(a,e,o,t,r,i){return _(),p("form",{class:"m-2",onSubmit:e[3]||(e[3]=A((...n)=>t.createKeep&&t.createKeep(...n),["prevent"])),id:"keep-form"},[s("div",Qe,[Je,k(s("input",{class:"form-control","onUpdate:modelValue":e[0]||(e[0]=n=>t.editable.name=n),type:"text",required:""},null,512),[[$,t.editable.name]])]),s("div",Xe,[Ze,k(s("input",{class:"form-control","onUpdate:modelValue":e[1]||(e[1]=n=>t.editable.img=n),type:"text",required:""},null,512),[[$,t.editable.img]])]),s("div",et,[tt,k(s("input",{class:"form-control","onUpdate:modelValue":e[2]||(e[2]=n=>t.editable.description=n),type:"text",required:""},null,512),[[$,t.editable.description]])]),ot],32)}var st=w(We,[["render",at]]),nt=Object.freeze({__proto__:null,[Symbol.toStringTag]:"Module",default:st});const rt="modulepreload",ee={},ct="/",O=function(e,o){return!o||o.length===0?e():Promise.all(o.map(t=>{if(t=`${ct}${t}`,t in ee)return;ee[t]=!0;const r=t.endsWith(".css"),i=r?'[rel="stylesheet"]':"";if(document.querySelector(`link[href="${t}"]${i}`))return;const n=document.createElement("link");if(n.rel=r?"stylesheet":rt,r||(n.as="script",n.crossOrigin=""),n.href=t,document.head.appendChild(n),r)return new Promise((v,d)=>{n.addEventListener("load",v),n.addEventListener("error",d)})})).then(()=>e())};function it(a){switch(a){case"./pages/AccountPage.vue":return O(()=>import("./AccountPage.0a99208b.js"),["assets/AccountPage.0a99208b.js","assets/AccountPage.a1bcf6d3.css","assets/vendor.f59b7483.js","assets/ProfilesService.3e570c3c.js"]);case"./pages/HomePage.vue":return O(()=>import("./HomePage.42471512.js"),["assets/HomePage.42471512.js","assets/HomePage.21ea7011.css","assets/vendor.f59b7483.js"]);case"./pages/ProfilePage.vue":return O(()=>import("./ProfilePage.c11c7710.js"),["assets/ProfilePage.c11c7710.js","assets/ProfilePage.013a8e3c.css","assets/vendor.f59b7483.js","assets/ProfilesService.3e570c3c.js"]);case"./pages/VaultPage.vue":return O(()=>import("./VaultPage.7b67bee8.js"),["assets/VaultPage.7b67bee8.js","assets/VaultPage.ff7a4efd.css","assets/vendor.f59b7483.js"]);default:return new Promise(function(e,o){(typeof queueMicrotask=="function"?queueMicrotask:setTimeout)(o.bind(null,new Error("Unknown variable dynamic import: "+a)))})}}function M(a){return()=>it(`./pages/${a}.vue`)}const lt=[{path:"/",name:"Home",component:M("HomePage")},{path:"/vault/:id",name:"Vault",component:M("VaultPage"),beforeEnter:G},{path:"/profile/:id",name:"Profile",component:M("ProfilePage"),beforeEnter:G},{path:"/account",name:"Account",component:M("AccountPage"),beforeEnter:me}],T=_e({linkActiveClass:"router-link-active",linkExactActiveClass:"router-link-exact-active",history:pe(),routes:lt});class dt{async getKeepsInVaults(e){try{const o=await m.get(`api/vaults/${e}/keeps`);l.log("Get Keeps in this Vault",o.data),c.vaultKeeps=o.data}catch(o){T.push({name:"Home"}),u.toast(o,"error")}}async createVaultKeep(e,o){let t={vaultId:o,keepId:e};const r=await m.post("api/vaultkeeps",t);return l.log("Create keep in a Vault",r.data),c.vaultKeeps.push(r.data),c.activeKeep.kept++,r.data}async removeVaultKeep(e){const o=await m.delete("api/vaultkeeps/"+e);l.log("Delete this vaultkeep",o.data);debugger;c.vaultKeeps=c.vaultKeeps.filter(t=>t.vaultKeepId!=e)}}const te=new dt;const ut={setup(a){const e=D({keepId:""});return W(),{keep:e,activeKeep:h(()=>c.activeKeep),account:h(()=>c.account),vaults:h(()=>c.vaults),myVaults:h(()=>c.myVaults),goToProfile(){K.getOrCreateInstance(document.getElementById("keep-details")).hide(),T.push({name:"Profile",params:{id:this.activeKeep.creator.id}})},async createVaultKeep(o,t){try{const r=await te.createVaultKeep(o,t);u.toast("Added to Vault","success")}catch(r){u.toast(r.message),l.error(r)}},async deleteKeep(o){try{if(await u.confirm("Delete Keep?","are you sure you want to delete?","info","Yes Delete")){const t=await I.deleteKeep(o);K.getOrCreateInstance(document.getElementById("keep-details")).hide(),u.toast("Keep Deleted")}}catch(t){u.toast(t.message),l.error(t)}}}}},_t=a=>(E("data-v-4137be13"),a=a(),P(),a),pt={class:"component",id:"keep-details"},mt={class:"row text-center"},vt={class:"col-md-4"},gt=["src","alt"],ft={class:"col-md-6"},ht={class:"pb-2 border-bottom border-secondary ms-4 d-flex flex-column justify-content-center"},bt={class:"mdi mdi-eye text-primary p-2"},yt={class:"m-1 text-dark"},kt={class:"mdi mdi-lock text-primary p-2"},wt={class:"m-1 text-dark"},xt={class:"mb-5 text-black mt-5"},Kt={class:"text-start text-black"},Vt={class:"row-reverse"},$t={class:"col-md-12 p-2 d-flex offset-2 justify-content-evenly dropdown pb-2"},St=_t(()=>s("button",{class:"btn btn-primary dropdown-toggle",type:"button","data-bs-toggle":"dropdown","aria-expanded":"false"}," Add to a Vault ",-1)),Tt={class:"dropdown-menu"},At=["onClick","vault"],Ct={class:"pe-4"},Et=["src"],Pt={class:"p-2 text-dark"};function It(a,e,o,t,r,i){var n,v;return _(),p("div",pt,[s("div",mt,[s("div",vt,[s("img",{class:"p-1 img-fluid",src:t.activeKeep.img,alt:t.activeKeep.name+" picture"},null,8,gt)]),s("div",ft,[s("div",ht,[s("div",null,[s("i",bt,[s("span",yt,f(t.activeKeep.views),1)]),s("i",kt,[s("span",wt,f(t.activeKeep.kept),1)])]),s("h3",xt,f(t.activeKeep.name),1),s("p",Kt,f(t.activeKeep.description),1)])]),s("div",Vt,[s("div",$t,[St,s("ul",Tt,[s("li",null,[(_(!0),p(F,null,ve(t.myVaults,d=>(_(),p("a",{onClick:A(V=>t.createVaultKeep(t.activeKeep.id,d.id),["prevent"]),key:d.id,vault:d,class:"dropdown-item",href:"#"},f(d.name),9,At))),128))])]),k(s("i",{onClick:e[0]||(e[0]=d=>t.deleteKeep(t.activeKeep.id)),title:"Delete Keep",class:"selectable mdi mdi-delete text-danger fs-4"},null,512),[[Q,t.activeKeep.creatorId==t.account.id]]),s("div",Ct,[s("img",{class:"profile-picture selectable",title:"Got to profile page",onClick:e[1]||(e[1]=(...d)=>t.goToProfile&&t.goToProfile(...d)),src:(n=t.activeKeep.creator)==null?void 0:n.picture},null,8,Et),s("span",Pt,f((v=t.activeKeep.creator)==null?void 0:v.name),1)])])])])])}var Ot=w(ut,[["render",It],["__scopeId","data-v-4137be13"]]),Mt=Object.freeze({__proto__:null,[Symbol.toStringTag]:"Module",default:Ot});const Dt={connection:"connection",connected:"connected",disconnect:"disconnect",authenticate:"authenticate",authenticated:"authenticated",userConnected:"userConnected",userDisconnected:"userDisconnected",error:"error"};class jt{constructor(e=!1,o=Z){}on(e,o){var t;return(t=this.socket)==null||t.on(e,o.bind(this)),this}onConnected(e){l.log("[SOCKET_CONNECTION]",e),this.connected=!0,this.playback()}onAuthenticated(e){l.log("[SOCKET_AUTHENTICATED]",e),this.authenticated=!0,this.playback()}authenticate(e){var o;(o=this.socket)==null||o.emit(Dt.authenticate,e)}onError(e){l.error("[SOCKET_ERROR]",e)}enqueue(e,o){l.log("[ENQUEING_ACTION]",{action:e,payload:o}),this.queue.push({action:e,payload:o})}playback(){l.log("[SOCKET_PLAYBACK]");const e=[...this.queue];this.queue=[],e.forEach(o=>{this.emit(o.action,o.payload)})}emit(e,o=void 0){if(this.requiresAuth&&!this.authenticated)return this.enqueue(e,o);if(!this.connected)return this.enqueue(e,o);this.socket.emit(e,o)}}class qt extends jt{constructor(){super();this.on("error",this.onError)}onError(e){u.toast(e.message,"error")}}const oe=new qt;class Rt{async getThisVault(e){const o=await m.get("api/vaults/"+e);c.activeVault=o.data}async createVault(e){const o=await m.post("api/vaults",e);return l.log("Create a Vault",o.data),c.profileVaults.unshift(o.data),o.data}async deleteVault(e){const o=await m.delete("api/vaults/"+e);l.log("Delete this vault",o.data),c.vaults=c.vaults.filter(t=>t.id!=e),T.push({name:"Home"})}}const Nt=new Rt,b=ge({domain:Te,clientId:Ae,audience:Ce,useRefreshTokens:!0,onRedirectCallback:a=>{T.push(a&&a.targetUrl?a.targetUrl:window.location.pathname)}});b.on(b.AUTH_EVENTS.AUTHENTICATED,async function(){m.defaults.headers.authorization=b.bearer,m.interceptors.request.use(Lt),c.user=b.user,await R.getAccount(),oe.authenticate(b.bearer),await R.getMyVaults()});async function Lt(a){if(!b.isAuthenticated)return a;const e=b.identity.exp*1e3,o=e<Date.now(),t=e<Date.now()+1e3*60*60*12;return o?await b.loginWithPopup():t&&(await b.getTokenSilently(),m.defaults.headers.authorization=b.bearer,oe.authenticate(b.bearer)),a}const Bt={setup(){const a=q();return{user:h(()=>c.user),account:h(()=>c.account),async login(){b.loginWithPopup()},async logout(){b.logout({returnTo:window.location.origin})},goToProfile(){a.push({name:"Profile",params:{id:c.account.id}})}}}},Ut=a=>(E("data-v-fd9f75c0"),a=a(),P(),a),Ft={class:"navbar-text"},zt={key:1,class:"dropdown my-2 my-lg-0"},Ht={class:"dropdown-toggle selectable","data-bs-toggle":"dropdown","aria-expanded":"false","aria-label":"User Login",id:"authDropdown"},Yt={class:"card bg-secondary"},Gt={key:0},Wt=["src"],Qt={class:"mx-3 text-light"},Jt={class:"dropdown-menu p-0 list-group w-100","aria-labelledby":"authDropdown"},Xt=Ut(()=>s("i",{class:"mdi mdi-logout"},null,-1)),Zt=S(" logout "),eo=[Xt,Zt];function to(a,e,o,t,r,i){return _(),p("span",Ft,[t.user.isAuthenticated?(_(),p("div",zt,[s("div",Ht,[s("div",Yt,[t.account.picture?(_(),p("div",Gt,[s("img",{src:t.account.picture,alt:"account photo",height:"40",class:"rounded p-0"},null,8,Wt),s("span",Qt,f(t.account.name),1)])):fe("",!0)])]),s("div",Jt,[s("div",{onClick:e[1]||(e[1]=(...n)=>t.goToProfile&&t.goToProfile(...n)),class:"list-group-item list-group-item-action hoverable"}," My Profile "),s("div",{class:"list-group-item list-group-item-action hoverable text-danger",onClick:e[2]||(e[2]=(...n)=>t.logout&&t.logout(...n))},eo)])])):(_(),p("button",{key:0,class:"btn selectable text-success lighten-30 text-uppercase my-2 my-lg-0",onClick:e[0]||(e[0]=(...n)=>t.login&&t.login(...n))}," Login "))])}var oo=w(Bt,[["render",to],["__scopeId","data-v-fd9f75c0"]]),ao=Object.freeze({__proto__:null,[Symbol.toStringTag]:"Module",default:oo});const so={setup(){return{}}},no=a=>(E("data-v-5334e5f0"),a=a(),P(),a),ro={class:"modal fade",tabindex:"-1",role:"dialog","aria-labelledby":"modelTitleId","aria-hidden":"true"},co={class:"modal-dialog modal-xl modal-dialog-centered",role:"document"},io={class:"modal-content"},lo={class:"modal-header bg-primary"},uo=no(()=>s("button",{type:"button",class:"btn-close","data-bs-dismiss":"modal","aria-label":"Close"},null,-1));function _o(a,e,o,t,r,i){return _(),p("div",ro,[s("div",co,[s("div",io,[s("div",lo,[J(a.$slots,"header",{class:"modal-title"},void 0,!0),uo]),J(a.$slots,"body",{class:"modal-body p-0"},void 0,!0)])])])}var po=w(so,[["render",_o],["__scopeId","data-v-5334e5f0"]]),mo=Object.freeze({__proto__:null,[Symbol.toStringTag]:"Module",default:po}),vo="/assets/newlogo.ff97de30.png";const go={setup(){return{}}},N=a=>(E("data-v-90619434"),a=a(),P(),a),fo={class:"navbar navbar-expand-lg navbar-dark bg-primary px-3"},ho=N(()=>s("div",{class:"d-flex flex-column align-items-center"},[s("img",{alt:"logo",src:vo,height:"45"})],-1)),bo=N(()=>s("button",{class:"navbar-toggler",type:"button","data-bs-toggle":"collapse","data-bs-target":"#navbarText","aria-controls":"navbarText","aria-expanded":"false","aria-label":"Toggle navigation"},[s("span",{class:"navbar-toggler-icon"})],-1)),yo={class:"collapse navbar-collapse",id:"navbarText"},ko=N(()=>s("ul",{class:"navbar-nav me-auto"},null,-1));function wo(a,e,o,t,r,i){const n=x("router-link"),v=x("Login");return _(),p("nav",fo,[g(n,{class:"navbar-brand d-flex",to:{name:"Home"}},{default:y(()=>[ho]),_:1}),bo,s("div",yo,[ko,g(v)])])}var xo=w(go,[["render",wo],["__scopeId","data-v-90619434"]]),Ko=Object.freeze({__proto__:null,[Symbol.toStringTag]:"Module",default:xo});const Vo={props:{vault:{type:Object,required:!0}},setup(a){const e=q();return{goToVaultPage(){K.getOrCreateInstance(document.getElementById("keep-details")).hide(),e.push({name:"Vault",params:{id:a.vault.id}})},async setActive(){try{I.setActive(a.keep)}catch(o){u.toast("Something went wrong","error"),l.error(o)}}}}},$o={class:"text-light text-center mt-4"};function So(a,e,o,t,r,i){return _(),p("div",{class:"col-md-2 m-2 p-4 card elevation-3 justify-content-end bg-secondary selectable lighten-20",onClick:e[0]||(e[0]=(...n)=>t.goToVaultPage&&t.goToVaultPage(...n)),style:Y(`background-image: url(${o.vault.img});`)},[s("h6",$o,f(o.vault.name),1)],4)}var To=w(Vo,[["render",So],["__scopeId","data-v-c6d760c6"]]),Ao=Object.freeze({__proto__:null,[Symbol.toStringTag]:"Module",default:To});const Co={setup(){const a=j({});return H(()=>{}),{editable:a,async createVault(){try{await Nt.createVault(a.value),K.getOrCreateInstance(document.getElementById("create-vault")).hide(),a.value={},u.toast("Vault Created!")}catch(e){l.error(e),u.toast(e.message,"error")}}}}},Eo={class:"mb-3 text-black"},Po=s("label",null,"Title",-1),Io={class:"mb-3 text-black"},Oo=s("label",null,"Image Url",-1),Mo={class:"mb-3 text-black"},Do=s("label",null,"Description",-1),jo={class:"mb-3 text-black"},qo=s("label",{class:"fs-5"}," Private?",-1),Ro=s("button",{class:"btn btn-primary"},"Create Vault!",-1);function No(a,e,o,t,r,i){return _(),p("form",{class:"m-2",onSubmit:e[4]||(e[4]=A((...n)=>t.createVault&&t.createVault(...n),["prevent"])),id:"create-vault"},[s("div",Eo,[Po,k(s("input",{class:"form-control","onUpdate:modelValue":e[0]||(e[0]=n=>t.editable.name=n),type:"text",required:""},null,512),[[$,t.editable.name]])]),s("div",Io,[Oo,k(s("input",{class:"form-control","onUpdate:modelValue":e[1]||(e[1]=n=>t.editable.img=n),type:"text",required:""},null,512),[[$,t.editable.img]])]),s("div",Mo,[Do,k(s("input",{class:"form-control","onUpdate:modelValue":e[2]||(e[2]=n=>t.editable.description=n),type:"text",required:""},null,512),[[$,t.editable.description]])]),s("div",jo,[k(s("input",{class:"m-1","onUpdate:modelValue":e[3]||(e[3]=n=>t.editable.isPrivate=n),type:"checkbox"},null,512),[[he,t.editable.isPrivate]]),qo]),Ro],32)}var Lo=w(Co,[["render",No]]),Bo=Object.freeze({__proto__:null,[Symbol.toStringTag]:"Module",default:Lo});const Uo={setup(a){const e=D({keepId:""});return W(),{keep:e,activeKeep:h(()=>c.activeKeep),account:h(()=>c.account),vaults:h(()=>c.vaults),myVaults:h(()=>c.myVaults),goToProfile(){K.getOrCreateInstance(document.getElementById("vault-details")).hide(),T.push({name:"Profile",params:{id:this.activeKeep.creator.id}})},async removeVaultKeep(o){try{if(await u.confirm("Remove Keep From Vault?","are you sure you want to remove?","info","Yes Remove")){const t=await te.removeVaultKeep(o);K.getOrCreateInstance(document.getElementById("vault-details")).hide(),u.toast("Keep Removed")}}catch(t){u.toast(t.message),l.error(t)}}}}},Fo={class:"component",id:"vault-details"},zo={class:"row text-center"},Ho={class:"col-md-4"},Yo=["src","alt"],Go={class:"col-md-6"},Wo={class:"pb-2 border-bottom border-secondary ms-4 d-flex flex-column justify-content-center"},Qo={class:"mb-5 mt-5 text-black"},Jo={class:"text-start text-black"},Xo={class:"row-reverse"},Zo={class:"col-md-12 d-flex p-2 offset-2 justify-content-evenly dropdown pb-2"},ea=["src"],ta={class:"p-2 text-black"};function oa(a,e,o,t,r,i){var n,v,d;return _(),p("div",Fo,[s("div",zo,[s("div",Ho,[s("img",{class:"p-1 img-fluid",src:t.activeKeep.img,alt:t.activeKeep.name+" picture"},null,8,Yo)]),s("div",Go,[s("div",Wo,[s("h3",Qo,f(t.activeKeep.name),1),s("p",Jo,f(t.activeKeep.description),1)])]),s("div",Xo,[s("div",Zo,[k(s("button",{onClick:e[0]||(e[0]=V=>t.removeVaultKeep(t.activeKeep.vaultKeepId)),class:"btn btn-danger",type:"button"}," Remove From Vault ",512),[[Q,((n=t.activeKeep.creator)==null?void 0:n.id)==t.account.id]]),s("div",null,[s("img",{class:"profile-picture",onClick:e[1]||(e[1]=(...V)=>t.goToProfile&&t.goToProfile(...V)),src:(v=t.activeKeep.creator)==null?void 0:v.picture},null,8,ea),s("span",ta,f((d=t.activeKeep.creator)==null?void 0:d.name),1)])])])])])}var aa=w(Uo,[["render",oa],["__scopeId","data-v-d1025b00"]]),sa=Object.freeze({__proto__:null,[Symbol.toStringTag]:"Module",default:aa});function na(a){Object.entries({"./components/AccountForm.vue":Ne,"./components/Kep.vue":Ge,"./components/KepForm.vue":nt,"./components/KepModal.vue":Mt,"./components/Login.vue":ao,"./components/Modal.vue":mo,"./components/Navbar.vue":Ko,"./components/Vault.vue":Ao,"./components/VaultForm.vue":Bo,"./components/VaultModal.vue":sa}).forEach(([o,t])=>{const r=t.name||o.substr(o.lastIndexOf("/")+1).replace(/\.\w+$/,"");a.component(r,t.default)})}const ae=be(Se);na(ae);ae.use(T).mount("#app");export{c as A,u as P,w as _,m as a,Nt as b,I as k,l,te as v};
