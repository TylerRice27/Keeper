import{s as k,H as y,c as l,a as u,o as i,b as d,d as e,t as n,j as m,y as _,F as f,x as g,z as K,A as w,I as v}from"./vendor.f59b7483.js";import{_ as A,l as P,P as S,A as r}from"./index.e1b1ec10.js";import{p}from"./ProfilesService.6fe14eec.js";const C={name:"Profile",setup(t){const a=k();return y(async()=>{try{await p.getProfile(a.params.id),await p.getUsersVaults(a.params.id),await p.getUsersKeeps(a.params.id)}catch(c){P.error(c),S.toast(c.message,"error")}}),{account:l(()=>r.account),profile:l(()=>r.activeProfile),keeps:l(()=>r.keeps),profileKeeps:l(()=>r.profileKeeps),profileVaults:l(()=>r.profileVaults),myVaults:l(()=>r.myVaults),vaults:l(()=>r.vaults)}}},h=t=>(K("data-v-27ce595e"),t=t(),w(),t),x={class:"container-fluid"},I={class:"d-flex col-md-12 mt-4"},j=["src"],B={class:"mt-3"},D={class:"p-1"},E={class:"p-1"},F={class:"p-1"},U={class:"row"},z={class:"col-md-12 mt-5 d-flex"},H=h(()=>e("h1",null,"Vaults",-1)),L={class:"row m-2"},M={class:"row"},N={class:"col-md-12 mt-5 d-flex"},R=h(()=>e("h1",null,"Keeps",-1)),q={class:"masonry-with-columns"};function G(t,a,c,o,J,O){const V=u("Vault"),b=u("Kep");return i(),d("div",x,[e("div",I,[e("img",{class:"rounded m-3 img-fluid selectable logo",src:o.profile.picture,title:"Edit Account",alt:"",onClick:a[0]||(a[0]=(...s)=>t.editAccount&&t.editAccount(...s)),"data-bs-toggle":"modal","data-bs-target":"#editAccount-form"},null,8,j),e("div",B,[e("h1",D,n(o.profile.name),1),e("h3",E,"Vaults: "+n(o.profileVaults.length),1),e("h3",F,"Keeps: "+n(o.profileKeeps.length),1)])]),e("div",U,[e("div",z,[H,m(e("i",{onClick:a[1]||(a[1]=(...s)=>t.createVault&&t.createVault(...s)),title:"Create a Vault","data-bs-toggle":"modal","data-bs-target":"#create-vault",class:"mdi mdi-plus fs-1 text-primary selectable"},null,512),[[_,o.profile.id==o.account.id]])])]),e("div",L,[(i(!0),d(f,null,g(o.profileVaults,s=>(i(),v(V,{key:s.id,vault:s},null,8,["vault"]))),128))]),e("div",M,[e("div",N,[R,m(e("i",{onClick:a[2]||(a[2]=(...s)=>t.createKeep&&t.createKeep(...s)),title:"Create a Keep","data-bs-toggle":"modal","data-bs-target":"#create-keep",class:"mdi mdi-plus fs-1 text-primary selectable"},null,512),[[_,o.profile.id==o.account.id]])])]),e("div",q,[(i(!0),d(f,null,g(o.profileKeeps,s=>(i(),v(b,{"data-bs-toggle":"modal","data-bs-target":"#keep-details",key:s.id,keep:s},null,8,["keep"]))),128))])])}var X=A(C,[["render",G],["__scopeId","data-v-27ce595e"]]);export{X as default};
