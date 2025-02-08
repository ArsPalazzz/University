(function (cjs, an) {

var p; // shortcut to reference prototypes
var lib={};var ss={};var img={};
lib.ssMetadata = [];


(lib.AnMovieClip = function(){
	this.actionFrames = [];
	this.ignorePause = false;
	this.currentSoundStreamInMovieclip;
	this.soundStreamDuration = new Map();
	this.streamSoundSymbolsList = [];

	this.gotoAndPlayForStreamSoundSync = function(positionOrLabel){
		cjs.MovieClip.prototype.gotoAndPlay.call(this,positionOrLabel);
	}
	this.gotoAndPlay = function(positionOrLabel){
		this.clearAllSoundStreams();
		var pos = this.timeline.resolve(positionOrLabel);
		if (pos != null) { this.startStreamSoundsForTargetedFrame(pos); }
		cjs.MovieClip.prototype.gotoAndPlay.call(this,positionOrLabel);
	}
	this.play = function(){
		this.clearAllSoundStreams();
		this.startStreamSoundsForTargetedFrame(this.currentFrame);
		cjs.MovieClip.prototype.play.call(this);
	}
	this.gotoAndStop = function(positionOrLabel){
		cjs.MovieClip.prototype.gotoAndStop.call(this,positionOrLabel);
		this.clearAllSoundStreams();
	}
	this.stop = function(){
		cjs.MovieClip.prototype.stop.call(this);
		this.clearAllSoundStreams();
	}
	this.startStreamSoundsForTargetedFrame = function(targetFrame){
		for(var index=0; index<this.streamSoundSymbolsList.length; index++){
			if(index <= targetFrame && this.streamSoundSymbolsList[index] != undefined){
				for(var i=0; i<this.streamSoundSymbolsList[index].length; i++){
					var sound = this.streamSoundSymbolsList[index][i];
					if(sound.endFrame > targetFrame){
						var targetPosition = Math.abs((((targetFrame - sound.startFrame)/lib.properties.fps) * 1000));
						var instance = playSound(sound.id);
						var remainingLoop = 0;
						if(sound.offset){
							targetPosition = targetPosition + sound.offset;
						}
						else if(sound.loop > 1){
							var loop = targetPosition /instance.duration;
							remainingLoop = Math.floor(sound.loop - loop);
							if(targetPosition == 0){ remainingLoop -= 1; }
							targetPosition = targetPosition % instance.duration;
						}
						instance.loop = remainingLoop;
						instance.position = Math.round(targetPosition);
						this.InsertIntoSoundStreamData(instance, sound.startFrame, sound.endFrame, sound.loop , sound.offset);
					}
				}
			}
		}
	}
	this.InsertIntoSoundStreamData = function(soundInstance, startIndex, endIndex, loopValue, offsetValue){ 
 		this.soundStreamDuration.set({instance:soundInstance}, {start: startIndex, end:endIndex, loop:loopValue, offset:offsetValue});
	}
	this.clearAllSoundStreams = function(){
		this.soundStreamDuration.forEach(function(value,key){
			key.instance.stop();
		});
 		this.soundStreamDuration.clear();
		this.currentSoundStreamInMovieclip = undefined;
	}
	this.stopSoundStreams = function(currentFrame){
		if(this.soundStreamDuration.size > 0){
			var _this = this;
			this.soundStreamDuration.forEach(function(value,key,arr){
				if((value.end) == currentFrame){
					key.instance.stop();
					if(_this.currentSoundStreamInMovieclip == key) { _this.currentSoundStreamInMovieclip = undefined; }
					arr.delete(key);
				}
			});
		}
	}

	this.computeCurrentSoundStreamInstance = function(currentFrame){
		if(this.currentSoundStreamInMovieclip == undefined){
			var _this = this;
			if(this.soundStreamDuration.size > 0){
				var maxDuration = 0;
				this.soundStreamDuration.forEach(function(value,key){
					if(value.end > maxDuration){
						maxDuration = value.end;
						_this.currentSoundStreamInMovieclip = key;
					}
				});
			}
		}
	}
	this.getDesiredFrame = function(currentFrame, calculatedDesiredFrame){
		for(var frameIndex in this.actionFrames){
			if((frameIndex > currentFrame) && (frameIndex < calculatedDesiredFrame)){
				return frameIndex;
			}
		}
		return calculatedDesiredFrame;
	}

	this.syncStreamSounds = function(){
		this.stopSoundStreams(this.currentFrame);
		this.computeCurrentSoundStreamInstance(this.currentFrame);
		if(this.currentSoundStreamInMovieclip != undefined){
			var soundInstance = this.currentSoundStreamInMovieclip.instance;
			if(soundInstance.position != 0){
				var soundValue = this.soundStreamDuration.get(this.currentSoundStreamInMovieclip);
				var soundPosition = (soundValue.offset?(soundInstance.position - soundValue.offset): soundInstance.position);
				var calculatedDesiredFrame = (soundValue.start)+((soundPosition/1000) * lib.properties.fps);
				if(soundValue.loop > 1){
					calculatedDesiredFrame +=(((((soundValue.loop - soundInstance.loop -1)*soundInstance.duration)) / 1000) * lib.properties.fps);
				}
				calculatedDesiredFrame = Math.floor(calculatedDesiredFrame);
				var deltaFrame = calculatedDesiredFrame - this.currentFrame;
				if((deltaFrame >= 0) && this.ignorePause){
					cjs.MovieClip.prototype.play.call(this);
					this.ignorePause = false;
				}
				else if(deltaFrame >= 2){
					this.gotoAndPlayForStreamSoundSync(this.getDesiredFrame(this.currentFrame,calculatedDesiredFrame));
				}
				else if(deltaFrame <= -2){
					cjs.MovieClip.prototype.stop.call(this);
					this.ignorePause = true;
				}
			}
		}
	}
}).prototype = p = new cjs.MovieClip();
// symbols:



(lib.тело = function(mode,startPosition,loop,reversed) {
if (loop == null) { loop = true; }
if (reversed == null) { reversed = false; }
	var props = new Object();
	props.mode = mode;
	props.startPosition = startPosition;
	props.labels = {};
	props.loop = loop;
	props.reversed = reversed;
	cjs.MovieClip.apply(this,[props]);

	// Слой_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f().s("#000000").ss(8,1,1).p("AKzCsQhSA6ieAyQlHBlnNAAQnOAAlGhlQlHhlAAiPQAAiPFHhlQFGhlHOAAQHNAAFHBlQCcAxBSA6AKzCsQgEgDgFgDQhTg2AAhOQAAhNBTg2QADgCAEgCQBRgzBxAAQB2AABTA3QAuAeAVAmIEeiCIAAj6ASPAeIEeCCIAAD6ASPAeQAAACAAACQAABOhTA2QhTA3h2AAQhvAAhRgxAR/gdQAPAcABAf");
	this.shape.setTransform(34.325,-3);

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("#993300").s().p("AvXD0QlGhlAAiPQAAiOFGhlQFHhlHOAAQHNAAFGBlQCdAwBSA6IgHAFQhTA2AABNQAABNBTA2IAJAGQhSA7ifAxQlGBlnNAAQnOAAlHhlgANCCIIgJgGQhTg2AAhNQAAhNBTg2IAHgFQBRgyBxAAQB1AABUA3QAuAeAVAlQAPAcABAhIAAADQAABNhTA2QhUA3h1AAQhvAAhRgxgANAiJIAAAAg");
	this.shape_1.setTransform(20.05,0.55);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape_1},{t:this.shape}]}).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-114.9,-47.9,298.5,89.9);


(lib.лапка = function(mode,startPosition,loop,reversed) {
if (loop == null) { loop = true; }
if (reversed == null) { reversed = false; }
	var props = new Object();
	props.mode = mode;
	props.startPosition = startPosition;
	props.labels = {};
	props.loop = loop;
	props.reversed = reversed;
	cjs.MovieClip.apply(this,[props]);

	// Слой_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f().s("#000000").ss(8,1,1).p("Aq2jkINvgBIH+HL");
	this.shape.setTransform(6.975,-4.875);

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f().s("#000000").ss(8,1,1).p("AqCk0INRBuIG0H7");
	this.shape_1.setTransform(1.775,3.075);

	this.shape_2 = new cjs.Shape();
	this.shape_2.graphics.f().s("#000000").ss(8,1,1).p("ApOmDIM0DcIFpIr");
	this.shape_2.setTransform(-3.425,10.975);

	this.shape_3 = new cjs.Shape();
	this.shape_3.graphics.f().s("#000000").ss(8,1,1).p("AoanSIMXFJIEeJc");
	this.shape_3.setTransform(-8.65,18.875);

	this.shape_4 = new cjs.Shape();
	this.shape_4.graphics.f().s("#000000").ss(8,1,1).p("AnmohIL5G3IDUKM");
	this.shape_4.setTransform(-13.85,26.775);

	this.shape_5 = new cjs.Shape();
	this.shape_5.graphics.f().s("#000000").ss(8,1,1).p("AoHlyILdDjIEyIC");
	this.shape_5.setTransform(-10.525,9.275);

	this.shape_6 = new cjs.Shape();
	this.shape_6.graphics.f().s("#000000").ss(8,1,1).p("AopjDILCAOIGRF5");
	this.shape_6.setTransform(-7.2,-8.225);

	this.shape_7 = new cjs.Shape();
	this.shape_7.graphics.f().s("#000000").ss(8,1,1).p("ApKBOIKljFIHwDv");
	this.shape_7.setTransform(-3.875,-35.625);

	this.shape_8 = new cjs.Shape();
	this.shape_8.graphics.f().s("#000000").ss(8,1,1).p("ApsDNIKJmZIJQBm");
	this.shape_8.setTransform(-0.55,-48.35);

	this.shape_9 = new cjs.Shape();
	this.shape_9.graphics.f().s("#000000").ss(8,1,1).p("AqNFJIJuptIKtgk");
	this.shape_9.setTransform(2.775,-60.75);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape}]}).to({state:[{t:this.shape_1}]},1).to({state:[{t:this.shape_2}]},1).to({state:[{t:this.shape_3}]},1).to({state:[{t:this.shape_4}]},1).to({state:[{t:this.shape_5}]},1).to({state:[{t:this.shape_6}]},1).to({state:[{t:this.shape_7}]},1).to({state:[{t:this.shape_8}]},1).to({state:[{t:this.shape_9}]},1).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-66.6,-97.6,147.1,183);


(lib.Символ4 = function(mode,startPosition,loop,reversed) {
if (loop == null) { loop = true; }
if (reversed == null) { reversed = false; }
	var props = new Object();
	props.mode = mode;
	props.startPosition = startPosition;
	props.labels = {};
	props.loop = loop;
	props.reversed = reversed;
	cjs.MovieClip.apply(this,[props]);

	// Слой_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f().s("#000000").ss(20,1,1).p("ADLq5InmLSII3Kh");
	this.shape.setTransform(28.4,69.775);

	this.timeline.addTween(cjs.Tween.get(this.shape).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-10,-10,76.8,159.6);


(lib.Символ3 = function(mode,startPosition,loop,reversed) {
if (loop == null) { loop = true; }
if (reversed == null) { reversed = false; }
	var props = new Object();
	props.mode = mode;
	props.startPosition = startPosition;
	props.labels = {};
	props.loop = loop;
	props.reversed = reversed;
	cjs.MovieClip.apply(this,[props]);

	// Слой_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f().s("#000000").ss(20,1,1).p("Ajwq3IAAWJADxrRIAAWj");
	this.shape.setTransform(24.05,72.175);

	this.timeline.addTween(cjs.Tween.get(this.shape).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-10,-10,68.1,164.4);


(lib.Символ2 = function(mode,startPosition,loop,reversed) {
if (loop == null) { loop = true; }
if (reversed == null) { reversed = false; }
	var props = new Object();
	props.mode = mode;
	props.startPosition = startPosition;
	props.labels = {};
	props.loop = loop;
	props.reversed = reversed;
	cjs.MovieClip.apply(this,[props]);

	// Слой_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("#252525").s().p("AmAsBIMBMBIsBMCg");
	this.shape.setTransform(38.5,77);

	this.timeline.addTween(cjs.Tween.get(this.shape).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(0,0,77,154);


(lib.Символ1 = function(mode,startPosition,loop,reversed) {
if (loop == null) { loop = true; }
if (reversed == null) { reversed = false; }
	var props = new Object();
	props.mode = mode;
	props.startPosition = startPosition;
	props.labels = {};
	props.loop = loop;
	props.reversed = reversed;
	cjs.MovieClip.apply(this,[props]);

	// Слой_2
	this.instance = new lib.лапка("synched",5);
	this.instance.setTransform(-436.2,-17.7,0.9999,0.9999,0,95.1892,-84.8108,76.3,17.9);

	this.instance_1 = new lib.лапка("synched",2);
	this.instance_1.setTransform(-509.3,3.95,0.9999,0.9999,0,95.1892,-84.8108,76.3,18);

	this.instance_2 = new lib.лапка("synched",4);
	this.instance_2.setTransform(-560.55,25.35,0.9999,0.9999,0,95.1892,-84.8108,76.4,18.1);

	this.instance_3 = new lib.лапка("synched",3);
	this.instance_3.setTransform(-353.2,321.2,1,1,14.9983,0,0,76.5,18.2);

	this.instance_4 = new lib.лапка("synched",0);
	this.instance_4.setTransform(-301.5,297.65,1,1,14.9983,0,0,76.4,18.1);

	this.instance_5 = new lib.лапка("synched",1);
	this.instance_5.setTransform(-245.75,260.05,1,1,14.9983,0,0,76.5,18.1);

	this.instance_6 = new lib.тело("synched",0);
	this.instance_6.setTransform(-434.6,169.1,1.2708,1.2708,-26.4555,0,0,34.1,-2.9);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_6},{t:this.instance_5,p:{startPosition:1}},{t:this.instance_4,p:{startPosition:0}},{t:this.instance_3,p:{startPosition:3}},{t:this.instance_2,p:{startPosition:4}},{t:this.instance_1,p:{startPosition:2}},{t:this.instance,p:{startPosition:5}}]}).to({state:[{t:this.instance_6},{t:this.instance_5,p:{startPosition:0}},{t:this.instance_4,p:{startPosition:9}},{t:this.instance_3,p:{startPosition:2}},{t:this.instance_2,p:{startPosition:3}},{t:this.instance_1,p:{startPosition:1}},{t:this.instance,p:{startPosition:4}}]},9).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-631.3,-21.9,410.49999999999994,397.4);


// stage content:
(lib.жукжук_HTML5Canvas = function(mode,startPosition,loop,reversed) {
if (loop == null) { loop = true; }
if (reversed == null) { reversed = false; }
	var props = new Object();
	props.mode = mode;
	props.startPosition = startPosition;
	props.labels = {};
	props.loop = loop;
	props.reversed = reversed;
	cjs.MovieClip.apply(this,[props]);

	this.actionFrames = [0,21];
	this.streamSoundSymbolsList[21] = [{id:"берсеркгатсоретmp3cutnet",startFrame:21,endFrame:60,loop:1,offset:0}];
	// timeline functions:
	this.frame_0 = function() {
		this.clearAllSoundStreams();
		 
		/* 
		
		startButton.addEventListener(MouseEvent.CLICK,f1);
		pauseButton.addEventListener(MouseEvent.CLICK,f2);
		backButton.addEventListener(MouseEvent.CLICK,f3);
		
		function f1(event):void{
			play();
		}
		
		function f2(event):void{
			stop();
		}
		
		function f3(event):void{
			gotoAndStop(0);
		}*/
		
		this.stop();
		this.startButton.addEventListener("click",f1.bind(this));
		function f1(args){this.play();} 
		
		this.pauseButton.addEventListener("click",f2.bind(this));
		function f2(args){this.stop();} 
		
		this.backButton.addEventListener("click",f3.bind(this));
		function f3(args){this.gotoAndStop(0);}
	}
	this.frame_21 = function() {
		var soundInstance = playSound("берсеркгатсоретmp3cutnet",0);
		this.InsertIntoSoundStreamData(soundInstance,21,60,1);
	}

	// actions tween:
	this.timeline.addTween(cjs.Tween.get(this).call(this.frame_0).wait(21).call(this.frame_21).wait(39));

	// Слой_1
	this.backButton = new lib.Символ4();
	this.backButton.name = "backButton";
	this.backButton.setTransform(678.8,362,1,1,0,0,0,28.4,69.8);
	new cjs.ButtonHelper(this.backButton, 0, 1, 1);

	this.pauseButton = new lib.Символ3();
	this.pauseButton.name = "pauseButton";
	this.pauseButton.setTransform(554.6,355.75,1,1,0,0,0,24.1,72.2);
	new cjs.ButtonHelper(this.pauseButton, 0, 1, 1);

	this.startButton = new lib.Символ2();
	this.startButton.name = "startButton";
	this.startButton.setTransform(431.7,358.6,1,1,0,0,0,38.5,77);
	new cjs.ButtonHelper(this.startButton, 0, 1, 1);

	this.shape = new cjs.Shape();
	this.shape.graphics.f().s("#000000").ss(1,1,1).p("AmAsBIAAYDIMBsCg");
	this.shape.setTransform(431.7,358.6);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape},{t:this.startButton},{t:this.pauseButton},{t:this.backButton}]}).wait(60));

	// видимая_метка
	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("#000000").s().p("AAIALQAHgCAGgDQgHAEgJABIADAAgAgbAAQgFgEgDgGIADAEQAFAGAHAEIACABQAGAFAHABQgNgCgJgJgAAigGIACgCIgEAGIACgEg");
	this.shape_1.setTransform(931.775,1026.075);

	this.shape_2 = new cjs.Shape();
	this.shape_2.graphics.f("#FF0000").s().p("AAIVbIgBAAIgFAAQgGgBgHgEIgCgBQgGgFgFgHIgDgEIoQsOQgHgLAAgMQAAgMAHgKIIFrrIoEtVIgcgcIEpjrIABAAIABABIAAABIi/DvIG7LdIAAsgIgLgfIAAAAIAAgBIgghcIAAgBIABgBIABABIAwAfIAghsIAAgBIABAAIABABIAgBsIA2gjIABAAIABABIgBABIgxCNIAAMSIG7rdIi+jvIAAgCIABAAIEDDNIAHAFIAAABIAGAGQALAMgCARQgCAQgNALIgEADIn8NIIIFLrQAHAKAAAMQAAAMgHALIoRMQIgCADIgCADIgDADIgFAEIgDACQgGADgHACIgDAAIgEAAgAAwSxIG7qQIm7qBgAnZIhIG6KPIAA0Pg");
	this.shape_2.setTransform(930.991,890.05);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape_2},{t:this.shape_1}]}).wait(60));

	// жук8
	this.instance = new lib.Символ1();
	this.instance.setTransform(932.7,911.85,0.0837,0.0997,-60.0037,0,0,-434.9,185.2);

	this.timeline.addTween(cjs.Tween.get(this.instance).to({x:931.8,y:816.55},9).to({guide:{path:[927.9,816.6,927.9,794.9,927.9,773.3,927.4,772.1,927,771], orient:'fixed'}},5).to({rotation:119.9963,x:931.8,y:862.05},5).to({scaleY:0.0996,rotation:112.7562,x:931.75,y:945.35},10).to({regY:185.6,rotation:-52.2474,x:931.8,y:1023.15},10).to({y:982.15},10).to({regY:185.2,scaleY:0.0997,rotation:-60.0037,guide:{path:[927.9,982.2,927.9,946.9,927.9,911.7], orient:'fixed'}},10).wait(1));

	// жук7
	this.instance_1 = new lib.Символ1();
	this.instance_1.setTransform(943.8,884.95,0.1285,0.1531,90,0,0,-434.9,184.9);

	this.timeline.addTween(cjs.Tween.get(this.instance_1).to({regX:-435.2,regY:184.1,scaleY:0.153,rotation:149.7271,guide:{path:[947.1,882.7,967.7,912.5,988.2,942.3], orient:'fixed'}},4).to({regX:-434.9,regY:185.5,rotation:243.1539,x:930.2,y:1015.75},5).to({regX:-435,regY:185.2,scaleY:0.1531,rotation:329.9972,x:879.9,y:942.8},10).to({x:931.55,y:868.05},10).to({regX:-434.9,scaleY:0.153,rotation:322.5143,x:967.85,y:808.05},10).to({rotation:142.5143,x:984.95,y:779.7},5).to({regX:-435.1,regY:184.9,rotation:152.9751,x:963.8,y:814.75},5).to({regX:-435.2,regY:185.2,rotation:77.9763,x:931.8,y:862.05},5).to({x:949.9,y:892.9},5).wait(1));

	// жук6
	this.instance_2 = new lib.Символ1();
	this.instance_2.setTransform(883.4,787.55,0.1286,0.1531,90,0,0,-434.4,185.2);

	this.timeline.addTween(cjs.Tween.get(this.instance_2).to({regX:-434.5,regY:184.6,rotation:149.9951,guide:{path:[880,789.6,877.7,785.9,875.5,782.2,874.1,780.8,872.7,779.4,887.5,767.7,902.4,755.9,902.4,755.9,902.5,755.8,902.5,755.9,902.6,755.9,902.6,756,902.6,756,893,768,883.5,780,905.6,816.6,927.8,853.2,927.8,813.3,927.8,773.3,927.2,771.8,926.7,770.2,926.7,770.2,926.7,770.2,926.7,770.2,926.7,770.1,925.1,765.5,923.5,760.9,923.5,760.9,923.5,760.8,923.5,760.8,923.6,760.7,923.6,760.8,923.7,760.8,926.1,762.4,928.5,763.9,930.1,758.5,931.8,753,931.8,753,931.8,752.9,931.8,752.9,931.9,752.9,931.9,753,932,753,933.5,758.4,935.1,763.8,937.8,762.1,940.6,760.4,940.6,760.4,940.7,760.3,940.7,760.4,940.8,760.4,940.7,760.5,940.7,760.5,938.2,767.6,935.8,774.7,935.8,814,935.8,853.3,957.9,816.7,980.1,780,970.6,768,961.1,756,961.1,756,961.1,755.9,961.1,755.9,961.2,755.9,974.1,766.2,987.1,776.4,987.5,776.6,987.8,776.9,987.8,776.9,987.8,776.9,988.1,777.2,988.4,777.5,989.5,778.8,989.3,780.5,989.1,782.1,987.8,783.2,987.6,783.3,987.4,783.4,962,825.5,936.6,867.5,962.4,904.9,988.3,942.2,989,943.3,989,944.5,989,945.7,988.3,946.7,988.2,946.8,988.2,946.8], orient:'fixed'}},19).to({regX:-435.2,regY:184.8,scaleX:0.1285,rotation:270,x:931.3,y:1022.45},10).to({regX:-434.5,regY:184.6,scaleX:0.1286,rotation:329.9951,x:878.75,y:944.55},10).to({regX:-435.1,regY:184.8,rotation:254.9983,x:931.55,y:868.05},10).to({regX:-435.2,regY:185.3,scaleX:0.1285,rotation:272.9942,x:923.95,y:854.55},1).to({regX:-435.1,regY:184.8,scaleX:0.1286,rotation:434.9983,x:879.2,y:780.45},9).wait(1));

	// жук5
	this.instance_3 = new lib.Символ1();
	this.instance_3.setTransform(1688.4,1142.95,0.2604,0.2604,-60.0019,0,0,-434.9,183.9);

	this.timeline.addTween(cjs.Tween.get(this.instance_3).to({regX:-434.8,regY:184,rotation:0,guide:{path:[1688.4,1140,1688.4,996.8,1778.8,895.5,1869.2,794.3,1997,794.3], orient:'fixed'}},59).wait(1));

	// жук4
	this.instance_4 = new lib.Символ1();
	this.instance_4.setTransform(113.75,835.35,0.3023,0.3023,29.9981,0,0,-434.5,183.8);

	this.timeline.addTween(cjs.Tween.get(this.instance_4).to({regX:-434.6,regY:183.9,rotation:-75.0013,guide:{path:[113.8,835.3,186.4,835.3,259,835.3]}},22).to({regX:-434.5,regY:183.6,rotation:-209.9996,guide:{path:[259,835.3,261.9,835.3,264.7,835.3,237.3,795.1,209.8,754.9,209.8,744.2,209.8,733.4,203.9,732.4,201,731.4,198,730.4,198,729.4,193.2,719.6,192.2,717.7,189.3,706.2,186.4,694.7]}},21).to({regY:183.8,rotation:-330.0019,guide:{path:[186.5,694.8,186.4,694.5,186.3,694.2,170.6,716.7,155,739.3,151,739.3,147.1,739.3,147.1,750.1,147.1,760.9,132.4,769.7,117.7,778.5,114.7,778.5,111.8,778.5,98.1,794.2,84.5,809.9,78.6,819.7,76.6,821.6,95.2,821.6,113.8,821.6,113.8,828.5,113.8,835.4]}},16).wait(1));

	// жук_3
	this.instance_5 = new lib.Символ1();
	this.instance_5.setTransform(648.85,181.5,0.3062,0.3062,60.0001,0,0,-434.5,183.6);

	this.timeline.addTween(cjs.Tween.get(this.instance_5).to({regY:183.7,scaleX:0.3061,scaleY:0.3061,rotation:15.0004,guide:{path:[648.9,181.5,660.4,202.2,688.3,218.8,735.9,247.1,803.2,247.1,814.3,247.1,824.9,246.3], orient:'fixed'}},22).to({regX:-434.4,regY:184,rotation:-119.9989,guide:{path:[824.9,246.3,878.3,242.4,917.9,218.8,965.5,190.5,965.5,150.5,965.5,110.6,917.9,82.3,913.2,79.5,908.3,77]}},21).to({regX:-434.3,regY:184.1,rotation:-270,guide:{path:[908.4,77,863.8,54.1,803.2,54.1,735.9,54.1,688.3,82.2,640.8,110.5,640.8,150.5,640.8,153.1,641,155.7]}},16).wait(1));

	// большой_таракан
	this.instance_6 = new lib.Символ1();
	this.instance_6.setTransform(1691.4,4.3,0.9759,0.9759,167.0467,0,0,-434.8,183.5);

	this.timeline.addTween(cjs.Tween.get(this.instance_6).to({regY:183.6,scaleX:1.2987,scaleY:1.2987,rotation:167.0459,guide:{path:[1691.4,4.5,1629.2,60.1,1576.6,125.4,1517,199.4,1467.7,281.2,1421.8,357.3,1369.7,429,1313.8,506,1243.7,567.7,1222.3,586.6,1191.8,585.8,1094.9,583.1,998.5,586,943.4,587.7,891.2,609.4,849.4,626.8,810.7,644.5,719.7,685.9,664.2,766.6,611.3,843.5,549.3,911.6,539.8,921.5,538.3,921.9,499.2,951.6,460.2,981.4,450.4,997.3,448,1001,444.3,1001,440.6,1001,407.6,1026.7,374.6,1052.4,374.6,1056,374.6,1059.7,368.4,1059.7,362.3,1059.7,354.9,1069.5,347.6,1079.3,329.9,1084.2,312.2,1089.1], orient:'fixed'}},59).wait(1));

	// маленький_таракан
	this.instance_7 = new lib.Символ1();
	this.instance_7.setTransform(65.45,42.55,0.5878,0.5878,90,0,0,-434.8,183.8);

	this.timeline.addTween(cjs.Tween.get(this.instance_7).to({regY:183.7,scaleX:0.5748,scaleY:0.5748,rotation:30.5871,x:866.95,y:553.65},32).to({regX:-434.7,regY:183.8,scaleX:0.5727,scaleY:0.5727,rotation:208.6271,guide:{path:[867,553.7,917.8,572.7,965.9,596.1,991.4,605.6,1017,615.1], orient:'fixed'}},5).to({regX:-434.6,scaleX:0.5707,scaleY:0.5707,rotation:386.7726,guide:{path:[1017.1,615.1,1093.1,643.5,1169.2,671.9], orient:'fixed'}},5).to({regX:-434.4,regY:183.5,scaleX:0.5639,scaleY:0.5639,rotation:450,guide:{path:[1169.1,671.9,1169.9,672.2,1170.7,672.5,1176.8,672.5,1182.9,672.5,1315.9,784,1448.9,895.6,1448.9,900.2,1448.9,904.8,1468.8,918.5,1488.6,932.3,1505.4,949.1,1522.2,965.9,1522.2,972,1522.2,978.2,1529.9,978.2,1537.5,978.2,1537.5,1007.2,1537.5,1036.3,1537.5,1036.3,1537.5,1036.3], orient:'fixed'}},17).wait(1));

	this._renderFirstFrame();

}).prototype = p = new lib.AnMovieClip();
p.nominalBounds = new cjs.Rectangle(919.7,382,1128.3,939.5);
// library properties:
lib.properties = {
	id: '79D226C63A9DA04FA4D1DE65A4788D23',
	width: 1920,
	height: 1080,
	fps: 30,
	color: "#FFFFFF",
	opacity: 1.00,
	manifest: [
		{src:"sounds/берсеркгатсоретmp3cutnet.mp3?1678038087699", id:"берсеркгатсоретmp3cutnet"}
	],
	preloads: []
};



// bootstrap callback support:

(lib.Stage = function(canvas) {
	createjs.Stage.call(this, canvas);
}).prototype = p = new createjs.Stage();

p.setAutoPlay = function(autoPlay) {
	this.tickEnabled = autoPlay;
}
p.play = function() { this.tickEnabled = true; this.getChildAt(0).gotoAndPlay(this.getTimelinePosition()) }
p.stop = function(ms) { if(ms) this.seek(ms); this.tickEnabled = false; }
p.seek = function(ms) { this.tickEnabled = true; this.getChildAt(0).gotoAndStop(lib.properties.fps * ms / 1000); }
p.getDuration = function() { return this.getChildAt(0).totalFrames / lib.properties.fps * 1000; }

p.getTimelinePosition = function() { return this.getChildAt(0).currentFrame / lib.properties.fps * 1000; }

an.bootcompsLoaded = an.bootcompsLoaded || [];
if(!an.bootstrapListeners) {
	an.bootstrapListeners=[];
}

an.bootstrapCallback=function(fnCallback) {
	an.bootstrapListeners.push(fnCallback);
	if(an.bootcompsLoaded.length > 0) {
		for(var i=0; i<an.bootcompsLoaded.length; ++i) {
			fnCallback(an.bootcompsLoaded[i]);
		}
	}
};

an.compositions = an.compositions || {};
an.compositions['79D226C63A9DA04FA4D1DE65A4788D23'] = {
	getStage: function() { return exportRoot.stage; },
	getLibrary: function() { return lib; },
	getSpriteSheet: function() { return ss; },
	getImages: function() { return img; }
};

an.compositionLoaded = function(id) {
	an.bootcompsLoaded.push(id);
	for(var j=0; j<an.bootstrapListeners.length; j++) {
		an.bootstrapListeners[j](id);
	}
}

an.getComposition = function(id) {
	return an.compositions[id];
}


an.makeResponsive = function(isResp, respDim, isScale, scaleType, domContainers) {		
	var lastW, lastH, lastS=1;		
	window.addEventListener('resize', resizeCanvas);		
	resizeCanvas();		
	function resizeCanvas() {			
		var w = lib.properties.width, h = lib.properties.height;			
		var iw = window.innerWidth, ih=window.innerHeight;			
		var pRatio = window.devicePixelRatio || 1, xRatio=iw/w, yRatio=ih/h, sRatio=1;			
		if(isResp) {                
			if((respDim=='width'&&lastW==iw) || (respDim=='height'&&lastH==ih)) {                    
				sRatio = lastS;                
			}				
			else if(!isScale) {					
				if(iw<w || ih<h)						
					sRatio = Math.min(xRatio, yRatio);				
			}				
			else if(scaleType==1) {					
				sRatio = Math.min(xRatio, yRatio);				
			}				
			else if(scaleType==2) {					
				sRatio = Math.max(xRatio, yRatio);				
			}			
		}
		domContainers[0].width = w * pRatio * sRatio;			
		domContainers[0].height = h * pRatio * sRatio;
		domContainers.forEach(function(container) {				
			container.style.width = w * sRatio + 'px';				
			container.style.height = h * sRatio + 'px';			
		});
		stage.scaleX = pRatio*sRatio;			
		stage.scaleY = pRatio*sRatio;
		lastW = iw; lastH = ih; lastS = sRatio;            
		stage.tickOnUpdate = false;            
		stage.update();            
		stage.tickOnUpdate = true;		
	}
}
an.handleSoundStreamOnTick = function(event) {
	if(!event.paused){
		var stageChild = stage.getChildAt(0);
		if(!stageChild.paused || stageChild.ignorePause){
			stageChild.syncStreamSounds();
		}
	}
}
an.handleFilterCache = function(event) {
	if(!event.paused){
		var target = event.target;
		if(target){
			if(target.filterCacheList){
				for(var index = 0; index < target.filterCacheList.length ; index++){
					var cacheInst = target.filterCacheList[index];
					if((cacheInst.startFrame <= target.currentFrame) && (target.currentFrame <= cacheInst.endFrame)){
						cacheInst.instance.cache(cacheInst.x, cacheInst.y, cacheInst.w, cacheInst.h);
					}
				}
			}
		}
	}
}


})(createjs = createjs||{}, AdobeAn = AdobeAn||{});
var createjs, AdobeAn;