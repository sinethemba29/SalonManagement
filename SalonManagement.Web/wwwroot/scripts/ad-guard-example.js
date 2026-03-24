// Example: guard a possibly-missing response.payload
async function initAd() {
  try {
    const res = await fetch('/some/ad/endpoint');
    const data = await res.json().catch(() => ({}));
    const payload = data?.payload;
    if (!payload) {
      console.warn('Ad payload missing, skipping ad init');
      return;
    }
    // safe to use payload.payloadField ...
  }
  catch (e) {
    console.warn('Ad init failed', e);
  }
}